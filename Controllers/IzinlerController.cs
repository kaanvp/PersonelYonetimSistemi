using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonelYonetimSistemi.Models;
using PersonelYonetimSistemiNew.Data;
using PersonelYonetimSistemiNew.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PersonelYonetimSistemiNew.Controllers
{
    public class IzinlerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IzinlerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string filter = "Tümü")
        {
            var izinlerQuery = _context.Izinler
                .Include(i => i.Personel)
                .Include(i => i.Pozisyon)
                .AsQueryable();

            // Filtreleme işlemi
            if (filter != "Tümü")
            {
                if (filter == "Onaylanan")
                {
                    izinlerQuery = izinlerQuery.Where(i => i.Status == "Onaylandı");
                }
                else if (filter == "Reddedilen")
                {
                    izinlerQuery = izinlerQuery.Where(i => i.Status == "Reddedildi");
                }
                else if (filter == "Onay Bekleyen")
                {
                    izinlerQuery = izinlerQuery.Where(i => i.Status == "Bekliyor");
                }
            }

            ViewBag.CurrentFilter = filter;
            return View(await izinlerQuery.ToListAsync());
        }

        public IActionResult Create()
        {
            // Personel listesini al
            var personeller = _context.Personeller.Include(p => p.Pozisyon).ToList();
            ViewBag.Personeller = new SelectList(personeller, "Id", "FullName");
            ViewBag.Pozisyonlar = new SelectList(_context.Pozisyonlar, "Id", "Name");

            // Personel-Pozisyon eşleştirme verilerini oluştur
            var personelPozisyonMap = new Dictionary<int, int>();
            foreach (var personel in personeller.Where(p => p.PozisyonId.HasValue))
            {
                personelPozisyonMap[personel.Id] = personel.PozisyonId.Value;
            }
            ViewBag.PersonelPozisyonMap = personelPozisyonMap;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Izinler izin, IFormFile permitFile)
        {
            if (ModelState.IsValid)
            {
                // Personelin pozisyonunu otomatik ata
                if (izin.PersonelId > 0 && izin.PozisyonId == null)
                {
                    var personel = await _context.Personeller.FindAsync(izin.PersonelId);
                    if (personel?.PozisyonId != null)
                    {
                        izin.PozisyonId = personel.PozisyonId;
                    }
                }

                // Dosya yükleme işlemi
                if (permitFile != null && permitFile.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/izin");
                    Directory.CreateDirectory(uploadsFolder);
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(permitFile.FileName);
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await permitFile.CopyToAsync(stream);
                    }
                    
                    izin.PermitFile = $"/uploads/izin/{uniqueFileName}";
                }

                izin.Status = "Bekliyor";
                _context.Add(izin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            // Form geçersiz olduğunda verileri tekrar yükle
            var personeller = _context.Personeller.Include(p => p.Pozisyon).ToList();
            ViewBag.Personeller = new SelectList(personeller, "Id", "FullName");
            ViewBag.Pozisyonlar = new SelectList(_context.Pozisyonlar, "Id", "Name");

            // Personel-Pozisyon eşleştirme verilerini oluştur
            var personelPozisyonMap = new Dictionary<int, int>();
            foreach (var personel in personeller.Where(p => p.PozisyonId.HasValue))
            {
                personelPozisyonMap[personel.Id] = personel.PozisyonId.Value;
            }
            ViewBag.PersonelPozisyonMap = personelPozisyonMap;
            
            return View(izin);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var izin = await _context.Izinler
                .Include(i => i.Personel)
                .Include(i => i.Pozisyon)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (izin == null)
            {
                return NotFound();
            }

            return View(izin);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var izin = await _context.Izinler.FindAsync(id);
            if (izin == null)
            {
                return NotFound();
            }
            
            ViewBag.Personeller = new SelectList(_context.Personeller, "Id", "FullName");
            ViewBag.Pozisyonlar = new SelectList(_context.Pozisyonlar, "Id", "Name");
            return View(izin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Izinler izin, IFormFile permitFile)
        {
            if (id != izin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Dosya yükleme işlemi
                    if (permitFile != null && permitFile.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/izin");
                        Directory.CreateDirectory(uploadsFolder);
                        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(permitFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await permitFile.CopyToAsync(stream);
                        }
                        
                        // Eski dosyayı sil
                        if (!string.IsNullOrEmpty(izin.PermitFile))
                        {
                            var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", izin.PermitFile.TrimStart('/'));
                            if (System.IO.File.Exists(oldFilePath))
                            {
                                System.IO.File.Delete(oldFilePath);
                            }
                        }
                        
                        izin.PermitFile = $"/uploads/izin/{uniqueFileName}";
                    }

                    _context.Update(izin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IzinExists(izin.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.Personeller = new SelectList(_context.Personeller, "Id", "FullName");
            ViewBag.Pozisyonlar = new SelectList(_context.Pozisyonlar, "Id", "Name");
            return View(izin);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var izin = await _context.Izinler
                .Include(i => i.Personel)
                .Include(i => i.Pozisyon)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (izin == null)
            {
                return NotFound();
            }

            return View(izin);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var izin = await _context.Izinler.FindAsync(id);
            
            // Dosyayı sil
            if (!string.IsNullOrEmpty(izin.PermitFile))
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", izin.PermitFile.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            
            _context.Izinler.Remove(izin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, string status)
        {
            var izin = await _context.Izinler.FindAsync(id);
            if (izin == null)
            {
                return NotFound();
            }

            izin.Status = status;
            _context.Update(izin);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private bool IzinExists(int id)
        {
            return _context.Izinler.Any(e => e.Id == id);
        }
    }
}