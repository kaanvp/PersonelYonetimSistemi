using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonelYonetimSistemiNew.Data;
using PersonelYonetimSistemi.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelYonetimSistemi.Controllers
{
    public class GirisCikisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GirisCikisController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(DateTime? baslangic, DateTime? bitis, string personelAdi = "", string durum = "")
        {
            // Varsayılan tarih aralığı - son 7 gün
            baslangic ??= DateTime.Today.AddDays(-7);
            bitis ??= DateTime.Today.AddDays(1);

            var query = _context.KullaniciHareketleri
                .Include(k => k.Personel)
                .Where(k => k.GirisZamani >= baslangic && k.GirisZamani <= bitis);

            // Personel adına göre filtreleme
            if (!string.IsNullOrEmpty(personelAdi))
            {
                query = query.Where(k => (k.Personel != null && 
                    (k.Personel.FirstName.Contains(personelAdi) || 
                     k.Personel.LastName.Contains(personelAdi))));
            }

            // Duruma göre filtreleme
            if (!string.IsNullOrEmpty(durum))
            {
                query = query.Where(k => k.Durum == durum);
            }

            // İstatistikler
            ViewBag.ToplamGiris = await query.CountAsync();
            ViewBag.ZamanindaGiris = await query.CountAsync(k => k.Durum == "Zamanında");
            ViewBag.GecGiris = await query.CountAsync(k => k.Durum == "Geç Giriş");
            ViewBag.ErkenCikis = await query.CountAsync(k => k.Durum == "Erken Çıkış");

            ViewBag.Baslangic = baslangic?.ToString("yyyy-MM-dd");
            ViewBag.Bitis = bitis?.ToString("yyyy-MM-dd");
            ViewBag.PersonelAdi = personelAdi;
            ViewBag.Durum = durum;

            var kayitlar = await query
                .OrderByDescending(k => k.GirisZamani)
                .ToListAsync();

            return View(kayitlar);
        }

        [HttpPost]
        public async Task<IActionResult> GirisKaydet(int personelId)
        {
            var personel = await _context.Personeller.FindAsync(personelId);
            if (personel == null)
                return NotFound();

            var mevcutGiris = await _context.KullaniciHareketleri
                .Where(k => k.PersonelId == personelId && !k.CikisZamani.HasValue)
                .FirstOrDefaultAsync();

            if (mevcutGiris != null)
                return BadRequest("Personelin aktif bir girişi zaten var.");

            var hareket = new KullaniciHareketleri
            {
                PersonelId = personelId,
                GirisZamani = DateTime.Now,
                IpAdresi = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Bilinmiyor",
                Durum = DateTime.Now.Hour >= 9 ? "Geç Giriş" : "Zamanında"
            };

            _context.KullaniciHareketleri.Add(hareket);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Giriş kaydı oluşturuldu." });
        }

        [HttpPost]
        public async Task<IActionResult> CikisKaydet(int personelId)
        {
            var hareket = await _context.KullaniciHareketleri
                .Where(k => k.PersonelId == personelId && !k.CikisZamani.HasValue)
                .OrderByDescending(k => k.GirisZamani)
                .FirstOrDefaultAsync();

            if (hareket == null)
                return NotFound("Aktif giriş kaydı bulunamadı.");

            hareket.CikisZamani = DateTime.Now;
            
            // Erken çıkış kontrolü (17:00'dan önce)
            if (DateTime.Now.Hour < 17)
            {
                hareket.Durum = "Erken Çıkış";
                hareket.Aciklama = $"Mesai saatinden önce çıkış yapıldı ({DateTime.Now:HH:mm})";
            }

            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Çıkış kaydı oluşturuldu." });
        }

        [HttpGet]
        public async Task<IActionResult> PersonelRaporu(int personelId, DateTime? baslangic, DateTime? bitis)
        {
            var personel = await _context.Personeller
                .Include(p => p.Departman)
                .Include(p => p.Pozisyon)
                .FirstOrDefaultAsync(p => p.Id == personelId);

            if (personel == null)
                return NotFound();

            baslangic ??= DateTime.Today.AddMonths(-1);
            bitis ??= DateTime.Today;

            var rapor = await _context.KullaniciHareketleri
                .Include(k => k.Personel)
                .Where(k => k.PersonelId == personelId &&
                           k.GirisZamani >= baslangic &&
                           k.GirisZamani <= bitis)
                .OrderByDescending(k => k.GirisZamani)
                .ToListAsync();

            ViewBag.Personel = personel;
            ViewBag.Baslangic = baslangic;
            ViewBag.Bitis = bitis;

            return View(rapor);
        }
    }
}