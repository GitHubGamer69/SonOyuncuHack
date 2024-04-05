namespace Tema_Giydirme.Models
{
    public class Iletisim
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Eposta { get; set; }
        public string Telefon { get; set; }
        public string Mesaj { get; set; }
        public bool OkunduMu { get; set; } = false;
        public DateTime Tarih { get; set; } = DateTime.Now;
    }
}
