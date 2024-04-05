using Microsoft.EntityFrameworkCore;

namespace Tema_Giydirme.Models
{
	public class EntityDbContext : DbContext
	{
		string baglanti = "Server=.;DataBase=MobilyaDb;Trusted_Connection=True;TrustServerCertificate=True;";

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(baglanti);
		}
		public DbSet<Kategori> Kategoriler { get; set; }
		public DbSet<FirmaBilgi> FirmaBilgileri { get; set; }
		public DbSet<Galeri> Galeri { get; set; }
		public DbSet<Iletisim> Iletisim { get; set; }
		public DbSet<Urun> Urunler { get; set; }
	}
}
