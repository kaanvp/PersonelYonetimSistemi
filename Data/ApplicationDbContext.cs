using Microsoft.EntityFrameworkCore;
using PersonelYonetimSistemi.Models;
using PersonelYonetimSistemiNew.Models;

namespace PersonelYonetimSistemiNew.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Izinler> Izinler { get; set; }
        public DbSet<Departman> Departmanlar { get; set; }
        public DbSet<Pozisyon> Pozisyonlar { get; set; }
        public DbSet<KullaniciHareketleri> KullaniciHareketleri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Personel>(entity =>
            {
                entity.Property(e => e.Salary)
                      .HasPrecision(18, 2); // Specify precision and scale
            });
        }
    }
}
