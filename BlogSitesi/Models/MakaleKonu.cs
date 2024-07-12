namespace BlogSitesi.Models
{
    public class MakaleKonu
    {
        public int MakaleKonuID { get; set; }
        public int KonuID { get; set; }
        public Konu? Konu { get; set; }
        public int MakaleID { get; set; }
        public Makale? Makale { get; set; }
    }
}
