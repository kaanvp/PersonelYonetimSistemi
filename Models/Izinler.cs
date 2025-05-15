using PersonelYonetimSistemi.Models;
using System.ComponentModel.DataAnnotations;

namespace PersonelYonetimSistemiNew.Models
{
    public class Izinler
    {
        public int Id { get; set; }

        [Display(Name = "Personel")]
        public int PersonelId { get; set; }
        
        public Personel? Personel { get; set; }

        [Display(Name = "İzin Türü")]
        public string? Name { get; set; }

        [Display(Name = "İzin Başlangıç Tarihi")]
        [DataType(DataType.Date)]
        public DateTime DateofStart { get; set; }

        [Display(Name = "İzin Gün Sayısı")]
        public int NumberofDays { get; set; }

        [Display(Name = "İzin Bitiş Tarihi")]
        [DataType(DataType.Date)]
        public DateTime DateofEnd => DateofStart.AddDays(NumberofDays);

        [Display(Name = "Pozisyon")]
        public int? PozisyonId { get; set; }
        
        public Pozisyon? Pozisyon { get; set; }

        [Display(Name = "İzin Belgesi")]
        public string? PermitFile { get; set; }

        [Display(Name = "Durum")]
        public string Status { get; set; } = "Bekliyor";
    }
}
