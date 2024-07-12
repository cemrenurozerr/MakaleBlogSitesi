using BlogSitesi.Models;

namespace BlogSitesi.DTOs
{
	public class ArticleDTO
	{
		public string MakaleBaslik { get; set; }

		public string MakaleIcerik { get; set; }

		public int OkunmaSuresi { get; set; }

		public List<Konu>? Konular { get; set; }

		public List<string>? SecilenKonular { get; set; }
	}
}
