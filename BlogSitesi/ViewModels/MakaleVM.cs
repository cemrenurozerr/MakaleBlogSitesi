using BlogSitesi.Models;

namespace BlogSitesi.ViewModels
{
	public class MakaleVM
	{
		public int? MemberID { get; set; }

		public List<string>? FollowedTopics { get; set; }

		public List<Makale>? Makaleler { get; set; }

		public List<Konu>? Konular { get; set; }

		public List<Konu>? TakipEdilebilenKonu { get; set; }

		public List<Konu>? TakipEdilenKonular { get; set; }
	}
}
