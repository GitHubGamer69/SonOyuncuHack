namespace Tema_Giydirme.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }
        public decimal Indirim { get; set; } = 0;
        public int Adet { get; set; } = 1;
        public string? Aciklama { get; set; }
        public int KategoriId { get; set; }
        public string? Gorsel { get; set; }
        public int Goruntuleme { get; set; } = 0;
        public DateTime Tarih { get; set; } = DateTime.Now;
        public bool Onay { get; set; } = true;
    }
}
