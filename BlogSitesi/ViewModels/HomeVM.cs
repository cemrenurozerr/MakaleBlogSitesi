using BlogSitesi.Models;

namespace BlogSitesi.ViewModels
{
    public class HomeVM
    {
        public List<Makale> Makaleler { get; set; }
        public List<Konu> Konular { get; set; }
    }
}
