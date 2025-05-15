using System.ComponentModel.DataAnnotations;

namespace PersonelYonetimSistemi.Models
{
    public class Pozisyon
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Pozisyon Adı")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Maaş Aralığı")]
        public string? SalaryRange { get; set; }

        [Display(Name = "İş Tanımı")]
        public string? JobDescription { get; set; }

        [Display(Name = "Gerekli Yetkinler ")]
        public string? RequiredSkills { get; set; }

        [Display(Name = "Pozisyon Durumu Açık")]
        public bool IsActive { get; set; } 
    }
}
