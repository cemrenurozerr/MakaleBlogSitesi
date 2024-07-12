using BlogSitesi.DAL;
using BlogSitesi.Models;
using BlogSitesi.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSitesi.Controllers
{
    public class MakaleController : Controller
    {
        private readonly BlogDBContext _context;
        private readonly UserManager<Kullanici> _userManager;

        public MakaleController(BlogDBContext context, UserManager<Kullanici> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var blogs = _context.Makaleler
            .Include(a => a.MakaleKonular)
                .ThenInclude(ac => ac.Konu)
            .Include(a => a.Kullanici).OrderByDescending(x=>x.OlusturulmaTarihi)
            .ToList();
            return View(blogs);
        }
		public IActionResult MakaleYaz()
		{
			var konular = _context.Konular.ToList();
			var viewModel = new MakaleEkleVM
			{
				Konular = konular
			};
			return View(viewModel);
		}


		[HttpPost]
		public async Task<IActionResult> MakaleYaz(MakaleEkleVM model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.GetUserAsync(User);
				if (user == null)
				{
					return Challenge();
				}

				var makale = new Makale
				{
					Baslik = model.Baslik,
					Icerik = model.Icerik,
					OlusturulmaTarihi = model.OlusturulmaTarihi,
					KullaniciId = user.Id,
					OrtalamaOkumaSuresi=model.OrtalamaOkumaSuresi
				};

				_context.Makaleler.Add(makale);
				await _context.SaveChangesAsync();

				foreach (var konuId in model.SelectedCategories)
				{
					var articleCategory = new MakaleKonu
					{
						MakaleID = makale.MakaleID,
						KonuID = konuId
					};
					_context.MakaleKonular.Add(articleCategory);
				}

				await _context.SaveChangesAsync();

				return RedirectToAction("Index");
			}

			model.Konular = _context.Konular.ToList();
			return View(model);

		}
		public IActionResult MakaleOku(int id)
		{
			
            var blogs = _context.Makaleler
            .Include(a => a.MakaleKonular)
                .ThenInclude(ac => ac.Konu)
            .Include(a => a.Kullanici)
            .ToList();

			var makale = blogs.FirstOrDefault(x => x.MakaleID == id);

            return View(makale);
		}

	}
}
