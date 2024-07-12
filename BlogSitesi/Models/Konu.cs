namespace BlogSitesi.Models
{
    public class Konu
    {
        public int KonuID { get; set; }
        public string Adi { get; set; }
        public ICollection<MakaleKonu>? MakaleKonular { get; set; }
        public ICollection<KullaniciKonu>? TakipEdilenler { get; set; }
    }
}
