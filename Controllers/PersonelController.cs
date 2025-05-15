using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PersonelYonetimSistemi.Models;
using PersonelYonetimSistemiNew.Data;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace PersonelYonetimSistemi.Controllers
{
    public class PersonelController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonelController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Personel
        public async Task<IActionResult> Index()
        {
            var personeller = _context.Personeller
        .Include(p => p.Departman)
        .Include(p => p.Pozisyon);
            return View(await personeller.ToListAsync());
        }

        // GET: Personel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personel = await _context.Personeller
                .Include(p => p.Departman)
                .Include(p => p.Pozisyon)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (personel == null)
            {
                return NotFound();
            }

            return View(personel);
        }

        // GET: Personel/Create
        public IActionResult Create()
        {
            try
            {
                // Make sure these tables exist and have data
                var departmanlar = _context.Departmanlar?.ToList();
                var pozisyonlar = _context.Pozisyonlar?.ToList();

                // Use proper type for the empty lists
                ViewBag.Departmanlar = departmanlar ?? new List<Departman>();
                ViewBag.Pozisyonlar = pozisyonlar ?? new List<Pozisyon>();
            }
            catch (Exception ex)
            {
                // Log the exception
                // Provide empty lists as fallback with the correct types
                ViewBag.Departmanlar = new List<Departman>();
                ViewBag.Pozisyonlar = new List<Pozisyon>();
            }

            return View();
        }

        // POST: Personel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Personel personel, IFormFile CvFile, IFormFile ContractFile)
        {
            if (ModelState.IsValid)
            {
                // CV Dosyasını Kaydet
                if (CvFile != null && CvFile.Length > 0)
                {
                    if (CvFile.Length <= 5 * 1024 * 1024 && (CvFile.ContentType == "application/pdf" || CvFile.ContentType == "application/msword" || CvFile.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document"))
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/cv");
                        Directory.CreateDirectory(uploadsFolder);
                        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(CvFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await CvFile.CopyToAsync(stream);
                        }
                        personel.CvFilePath = $"/uploads/cv/{uniqueFileName}";
                    }
                    else
                    {
                        ModelState.AddModelError("", "CV dosyası yalnızca PDF veya Word formatında ve 5MB'den küçük olmalıdır.");
                        return View(personel);
                    }
                }

                // Sözleşme Dosyasını Kaydet
                if (ContractFile != null && ContractFile.Length > 0)
                {
                    if (ContractFile.Length <= 5 * 1024 * 1024 && ContractFile.ContentType == "application/pdf")
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads/contracts");
                        Directory.CreateDirectory(uploadsFolder);
                        var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(ContractFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await ContractFile.CopyToAsync(stream);
                        }
                        personel.ContractFilePath = $"/uploads/contracts/{uniqueFileName}";
                    }
                    else
                    {
                        ModelState.AddModelError("", "Sözleşme dosyası yalnızca PDF formatında ve 5MB'den küçük olmalıdır.");
                        return View(personel);
                    }
                }

                try
                {
                    _context.Add(personel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Kayıt sırasında bir hata oluştu: {ex.Message}");
                    return View(personel);
                }
            }
            return View(personel);
        }

        // GET: Personel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                // Make sure these tables exist and have data
                var departmanlar = _context.Departmanlar?.ToList();
                var pozisyonlar = _context.Pozisyonlar?.ToList();

                // Use proper type for the empty lists
                ViewBag.Departmanlar = departmanlar ?? new List<Departman>();
                ViewBag.Pozisyonlar = pozisyonlar ?? new List<Pozisyon>();
            }
            catch (Exception ex)
            {
                // Log the exception
                // Provide empty lists as fallback with the correct types
                ViewBag.Departmanlar = new List<Departman>();
                ViewBag.Pozisyonlar = new List<Pozisyon>();
            }
            if (id == null)
            {
                return NotFound();
            }

            var personel = await _context.Personeller.FindAsync(id);
            if (personel == null)
            {
                return NotFound();
            }
            return View(personel);
        }

        // POST: Personel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpNum,FirstName,MidName,LastName,TCKN,Gender,MaritalStatus,PhoneNumber,EmailAddress,City,DateofBirth,Address,Salary,HireDate,BankName,IBAN,DepartmanId,PozisyonId,CvFilePath,ContractFilePath")] Personel personel)
        {
            if (id != personel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Güncelleme sırasında bir hata oluştu: {ex.Message}");
                    return View(personel);
                }
            }

            ViewBag.Departmanlar = _context.Departmanlar.ToList();
            ViewBag.Pozisyonlar = _context.Pozisyonlar.ToList();

            return View(personel);
        }

        // GET: Personel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personel = await _context.Personeller
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personel == null)
            {
                return NotFound();
            }

            return View(personel);
        }

        // POST: Personel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personel = await _context.Personeller.FindAsync(id);
            if (personel != null)
            {
                _context.Personeller.Remove(personel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonelExists(int id)
        {
            return _context.Personeller.Any(e => e.Id == id);
        }
    }
}
