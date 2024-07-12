using BlogSitesi.Models;

namespace BlogSitesi.ViewModels
{
    public class KullaniciVM
    {
        public KullaniciGuncelleVM? KullaniciGuncelle { get; set; }
        public Kullanici? Kullanici { get; set; }
        public List<Kullanici>? Kullanicilar { get; set; }
    }
}
