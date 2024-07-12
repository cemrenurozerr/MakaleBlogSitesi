namespace BlogSitesi.ViewModels
{
    public class KullaniciGuncelleVM
    {

        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public IFormFile? ProfilResmi { get; set; }
        public string? Biyografi { get; set; }
        public string? Email { get; set; }
    }
}
