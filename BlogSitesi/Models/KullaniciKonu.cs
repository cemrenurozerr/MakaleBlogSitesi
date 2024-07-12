namespace BlogSitesi.Models
{
    public class KullaniciKonu
    {
        public int KullaniciKonuID { get; set; }
        public int KonuID { get; set; }
        public Konu Konu { get; set; }
        public int KullaniciID { get; set; }
        public Kullanici Kullanici { get; set; }

    }
}
