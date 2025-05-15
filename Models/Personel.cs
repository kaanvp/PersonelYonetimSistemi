using System.ComponentModel.DataAnnotations;

namespace PersonelYonetimSistemi.Models
{
	public class Personel 
	{
		public int Id { get; set; }
		[Display(Name = "Personel No")]
		public string? EmpNum { get; set; }
		[Display(Name = "Ad")]
		public string? FirstName { get; set; }
		[Display(Name = "İkinci Ad")]
		public string? MidName { get; set; }
		[Display(Name = "Soyad")]
		public string? LastName { get; set; }
		[Display(Name = "Tam İsim")]
		public string? FullName => $"{FirstName} {MidName} {LastName}";
        [Display(Name = "TC Kimlik Numarası")]
        public string? TCKN { get; set; }
        [Display(Name = "Cinsiyet")]
        public string? Gender { get; set; }
        [Display(Name = "Medeni Hal")]
        public string? MaritalStatus { get; set; }
        [Display(Name = "Telefon Numarası")]
		public string? PhoneNumber { get; set; }
		[Display(Name = "E-posta Adresi")]
		public string? EmailAddress { get; set; }
		[Display(Name = "Şehir")]
		public string? City { get; set; }
		[Display(Name = "Doğum Tarihi")]
		public DateTime DateofBirth { get; set; }
		[Display(Name = "Adres")]
		public string? Address { get; set; }
		[Display(Name = "Maaş")]
		public decimal Salary { get; set; }
		[Display(Name = "İşe Giriş Tarihi")]
		public DateTime HireDate { get; set; }
		[Display(Name = "Banka İsmi")]
		public string? BankName { get; set; }
		[Display(Name = "IBAN")]
		public string? IBAN { get; set; }
        [Display(Name = "CV Dosya Yolu")]
        public string? CvFilePath { get; set; }
        [Display(Name = "Sözleşme Dosya Yolu")]
        public string? ContractFilePath { get; set; }
        [Display(Name = "Departman")]
        public int? DepartmanId { get; set; }
		public Departman? Departman { get; set; }
        [Display(Name = "Pozisyon")]
        public int? PozisyonId { get; set; }
		public Pozisyon? Pozisyon { get; set; }
	}
}
