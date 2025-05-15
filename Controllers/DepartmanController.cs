using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonelYonetimSistemiNew.Data;
using PersonelYonetimSistemi.Models;
using System.Threading.Tasks;

namespace PersonelYonetimSistemi.Controllers
{
    public class DepartmanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmanController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Departmanlar.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Departman departman)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(departman);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                // Loglama ekliyoruz
                ModelState.AddModelError("", $"Bir hata oluştu: {ex.Message}");
            }
            return View(departman);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departman = await _context.Departmanlar.FindAsync(id);
            if (departman == null)
            {
                return NotFound();
            }
            return View(departman);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Departman departman)
        {
            if (id != departman.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmanExists(departman.Id))
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
            return View(departman);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departman = await _context.Departmanlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departman == null)
            {
                return NotFound();
            }

            return View(departman);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departman = await _context.Departmanlar.FindAsync(id);
            if (departman == null) {
                return BadRequest("Entity cannot be null");
            }
            _context.Departmanlar.Remove(departman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmanExists(int id)
        {
            return _context.Departmanlar.Any(e => e.Id == id);
        }
    }
}