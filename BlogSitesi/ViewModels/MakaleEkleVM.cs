using BlogSitesi.Models;

namespace BlogSitesi.ViewModels
{
	public class MakaleEkleVM
	{
		public int KullaniciID { get; set; }
		public string Baslik { get; set; }
		public string Icerik { get; set; }
		public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
		public string OrtalamaOkumaSuresi { get; set; }
		public ICollection<Konu>? Konular { get; set; }
		public ICollection<int> SelectedCategories { get; set; }
	}
}
