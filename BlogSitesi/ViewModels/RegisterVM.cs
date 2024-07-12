using System.ComponentModel.DataAnnotations;

namespace BlogSitesi.ViewModels
{
    public class RegisterVM
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        [EmailAddress(ErrorMessage = "Email formatına uygun olmalıdır! Geçerli bir Email giriniz.")]
        public string Email { get; set; }
        public string Sifre { get; set; }
        [Compare("Sifre", ErrorMessage = "Şifreler aynı olmalıdır.")]
        public string SifreTekrari { get; set; }
    }
}
