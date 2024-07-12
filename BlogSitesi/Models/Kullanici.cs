using Microsoft.AspNetCore.Identity;

namespace BlogSitesi.Models
{
    public class Kullanici : IdentityUser<int>
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string? ProfilResmiYolu { get; set; }
        public string? Biyografi { get; set; }
        public bool AktifMi { get; set; } = false;
        public ICollection<Makale>? Makaleler { get; set; }
		public ICollection<KullaniciKonu>? TakipEdilenler { get; set; }
	}
}
