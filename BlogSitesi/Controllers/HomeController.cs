using BlogSitesi.DAL;
using BlogSitesi.Models;
using BlogSitesi.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BlogSitesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogDBContext _context;
        private readonly SignInManager<Kullanici> _signInManager;
		private readonly UserManager<Kullanici> _userManager;

		public HomeController(ILogger<HomeController> logger, BlogDBContext context, SignInManager<Kullanici> signInManager, UserManager<Kullanici> userManager)
		{
			_logger = logger;
			_context = context;
			_signInManager = signInManager;
			_userManager = userManager;
		}

		public IActionResult Index()
        {
			MakaleVM vm = new MakaleVM();



			vm.Makaleler = _context.Makaleler.Include(x => x.MakaleKonular).ThenInclude(ta => ta.Konu).Include(x => x.Kullanici).OrderByDescending(x => x.OkunmaSayisi).Take(4).ToList();

			vm.Konular = _context.Konular.Include(x => x.MakaleKonular).ThenInclude(at => at.Makale).ThenInclude(tm => tm.Kullanici).Where(topic => topic.MakaleKonular.Any(ta => ta.Makale != null)).ToList();

			if (_signInManager.IsSignedIn(User))
			{
				vm.TakipEdilebilenKonu = _context.Konular.ToList();
				vm.TakipEdilenKonular = _context.Konular.Include(x => x.TakipEdilenler).ThenInclude(tm => tm.Kullanici).Where(topic => topic.TakipEdilenler.Any(ta => ta.KullaniciID == GetUserID())).ToList();
			}

			return View(vm);
        }
		[HttpPost]
		public IActionResult Index(MakaleVM? vm)
		{
			if (vm.FollowedTopics.Count < 1)
			{
				TempData["Hata"] = "Hiç konu seçmediniz!";
				return RedirectToAction("Index", "Home");
			}
			else
				FollowTopics(vm.FollowedTopics);
			return RedirectToAction("Index", "Home");
		}

		public IActionResult Hakkinda()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
		public void FollowTopics(List<string> topics)
		{
			List<int> selectedTopics = topics.Select(int.Parse).ToList();
			foreach (var topicID in selectedTopics)
			{
				var memberTopic = new KullaniciKonu
				{
					KullaniciID = GetUserID(),
					KonuID = topicID
				};
				_context.KullaniciKonular.Add(memberTopic);
			}
			_context.SaveChanges();
		}
		public int GetUserID()
		{
			return int.Parse(_userManager.GetUserId(User));
		}
	}
}
