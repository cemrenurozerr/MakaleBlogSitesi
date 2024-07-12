namespace BlogSitesi.Models
{
    public class Makale
    {
        public int MakaleID { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
        public string OrtalamaOkumaSuresi { get; set; }
        public int? OkunmaSayisi { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        public ICollection<MakaleKonu>? MakaleKonular { get; set; }
    }
}
