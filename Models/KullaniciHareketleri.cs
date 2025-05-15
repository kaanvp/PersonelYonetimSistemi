using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using PersonelYonetimSistemi.Models;

namespace PersonelYonetimSistemi.Models
{
    public class KullaniciHareketleri
    {
        public int Id { get; set; }

        [Display(Name = "Personel Adı")]
        public string? KullaniciAdi { get; set; } = string.Empty;

        [Display(Name = "Personel")]
        public int PersonelId { get; set; }

        [Display(Name = "Personel")]
        public virtual Personel? Personel { get; set; }

        [Display(Name = "Giriş Zamanı")]
        public DateTime GirisZamani { get; set; }

        [Display(Name = "Çıkış Zamanı")]
        public DateTime? CikisZamani { get; set; }

        [Display(Name = "Durum")]
        public string? Durum { get; set; } // Zamanında, Geç Giriş, Erken Çıkış

        [Display(Name = "Açıklama")]
        public string? Aciklama { get; set; }

        [Display(Name = "IP Adresi")]
        public string? IpAdresi { get; set; }
    }
}
