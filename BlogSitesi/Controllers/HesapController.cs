using BlogSitesi.DAL;
using BlogSitesi.Models;
using BlogSitesi.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogSitesi.Controllers
{
    public class HesapController : Controller
    {
        private readonly BlogDBContext _context;
        private readonly UserManager<Kullanici> _userManager;
        private readonly SignInManager<Kullanici> _signInManager;

		public HesapController(BlogDBContext context, UserManager<Kullanici> userManager, SignInManager<Kullanici> signInManager)
		{
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Hesap()
        {
            var kullanici = _context.Users.FirstOrDefault(x => x.Id == GetUserID());
            return View(kullanici);
        }
        public IActionResult ProfilDuzenle()
        {
            KullaniciGuncelleVM kullaniciGuncelleVM = new KullaniciGuncelleVM();
            return View(kullaniciGuncelleVM);
        }
        [HttpPost]
        public IActionResult ProfilDuzenle(KullaniciGuncelleVM kullaniciGuncelleVM)
        {
            if (ModelState.IsValid)
            {
                var kullanici = _context.Users.FirstOrDefault(x => x.Id == GetUserID());
                kullanici.Ad = kullaniciGuncelleVM.Ad;
                kullanici.Soyad = kullaniciGuncelleVM.Soyad;
                kullanici.Biyografi = kullaniciGuncelleVM.Biyografi;
                kullanici.Email = kullaniciGuncelleVM.Email;
                _context.Users.Update(kullanici);
                _context.SaveChanges();
                return RedirectToAction("Hesap");

            }
            return View();
        }
        public IActionResult ProfilDegis()
        {
            KullaniciGuncelleVM kullaniciGuncelleVM = new KullaniciGuncelleVM();
            return View(kullaniciGuncelleVM);
        }
        [HttpPost]
        public IActionResult ProfilDegis(KullaniciGuncelleVM kullaniciGuncelleVM)
        {
            if (ModelState.IsValid)
            {
                var kullanici = _context.Users.FirstOrDefault(x => x.Id == GetUserID());
                Guid guid = Guid.NewGuid();
                string dosyaAdi = guid.ToString();
                dosyaAdi += kullaniciGuncelleVM.ProfilResmi.FileName;
                string dosyaYolu = "wwwroot/ProfilResimleri/";
                kullanici.ProfilResmiYolu = dosyaAdi;

                FileStream fs = new FileStream(dosyaYolu + dosyaAdi, FileMode.Create);
                kullaniciGuncelleVM.ProfilResmi.CopyTo(fs);
                fs.Close();
                _context.Users.Update(kullanici);
                _context.SaveChanges();
                return RedirectToAction("Hesap");
            }
            return View();
        }
        public IActionResult YazdigimMakaleler(int id)
        {
            if (!_signInManager.IsSignedIn(User))
            {
                TempData["Message"] = "Üye girişi yapmanız gerekmektedir";
                return RedirectToAction("Index","Makale");
            }
            var yazar = _context.Users
             .Include(u => u.Makaleler)
             .FirstOrDefault(u => u.Id == id);


            return View(yazar);
        }
        public IActionResult Delete(int? id)
        {
            Kullanici kullanici = _context.Users.FirstOrDefault(x => x.Id == id);
            return View(kullanici);
        }

        //POST: MenuController/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var kullanici = _context.Users.Find(id);
            
            if (kullanici != null)
            {
                _context.Users.Remove(kullanici);
            _context.SaveChanges();

            }
            _signInManager.SignOutAsync();
            TempData["HesapSilindi"] = "Hesabınız Başarıyla Silinmiştir";
            return RedirectToAction("Index","Home");
        }
        public int GetUserID()
        {
            if (User != null)
            {
            return int.Parse(_userManager.GetUserId(User));
            }
            return 0;
        }
    }
}
