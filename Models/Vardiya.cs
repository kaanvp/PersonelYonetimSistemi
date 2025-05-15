namespace PersonelYonetimSistemiNew.Models
{
	public class Vardiya
	{
		public int Id { get; set; }
		public string VardiyaAdi { get; set; }
		public TimeSpan BaslangicSaati { get; set; }
		public TimeSpan BitisSaati { get; set; }
		public virtual ICollection<PersonelVardiya> PersonelVardiyalar { get; set; }
	}
}
