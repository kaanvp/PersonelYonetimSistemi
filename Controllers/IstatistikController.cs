using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonelYonetimSistemiNew.Data;

namespace PersonelYonetimSistemi.Controllers
{
    public class IstatistikController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IstatistikController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Temel istatistikler
            var toplamPersonel = await _context.Personeller.CountAsync();
            var toplamDepartman = await _context.Departmanlar.CountAsync();
            var toplamPozisyon = await _context.Pozisyonlar.CountAsync();

            // Departmanlara göre personel dağılımı
            var departmanDagilimi = await _context.Personeller
                .Include(p => p.Departman)
                .Where(p => p.Departman != null)
                .GroupBy(p => p.Departman!.Name)
                .Select(g => new { 
                    DepartmanAdi = g.Key, 
                    PersonelSayisi = g.Count() 
                })
                .ToListAsync();

            // Pozisyonlara göre personel dağılımı
            var pozisyonDagilimi = await _context.Personeller
                .Include(p => p.Pozisyon)
                .Where(p => p.Pozisyon != null)
                .GroupBy(p => p.Pozisyon!.Name)
                .Select(g => new { 
                    PozisyonAdi = g.Key, 
                    PersonelSayisi = g.Count() 
                })
                .ToListAsync();

            // İzin durumları
            var izinDagilimi = await _context.Izinler
                .GroupBy(i => i.Name)
                .Select(g => new { 
                    IzinTuru = g.Key, 
                    IzinSayisi = g.Count() 
                })
                .ToListAsync();

            // ViewBag'e verileri aktar
            ViewBag.ToplamPersonel = toplamPersonel;
            ViewBag.ToplamDepartman = toplamDepartman;
            ViewBag.ToplamPozisyon = toplamPozisyon;

            // JSON formatında veri hazırla
            ViewBag.DepartmanLabels = departmanDagilimi.Select(x => x.DepartmanAdi).ToList();
            ViewBag.DepartmanData = departmanDagilimi.Select(x => x.PersonelSayisi).ToList();

            ViewBag.PozisyonLabels = pozisyonDagilimi.Select(x => x.PozisyonAdi).ToList();
            ViewBag.PozisyonData = pozisyonDagilimi.Select(x => x.PersonelSayisi).ToList();

            ViewBag.IzinLabels = izinDagilimi.Select(x => x.IzinTuru).ToList();
            ViewBag.IzinData = izinDagilimi.Select(x => x.IzinSayisi).ToList();

            return View();
        }
    }
}