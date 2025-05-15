using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonelYonetimSistemiNew.Data;
using PersonelYonetimSistemi.Models;
using System.Threading.Tasks;

namespace PersonelYonetimSistemi.Controllers
{
    public class PozisyonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PozisyonController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Pozisyonlar.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pozisyon pozisyon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pozisyon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pozisyon);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozisyon = await _context.Pozisyonlar.FindAsync(id);
            if (pozisyon == null)
            {
                return NotFound();
            }
            return View(pozisyon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pozisyon pozisyon)
        {
            if (id != pozisyon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pozisyon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PozisyonExists(pozisyon.Id))
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
            return View(pozisyon);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pozisyon = await _context.Pozisyonlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pozisyon == null)
            {
                return NotFound();
            }

            return View(pozisyon);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pozisyon = await _context.Pozisyonlar.FindAsync(id);
            if (pozisyon == null)
            {
                return NotFound();
            }
            _context.Pozisyonlar.Remove(pozisyon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PozisyonExists(int id)
        {
            return _context.Pozisyonlar.Any(e => e.Id == id);
        }
    }
}