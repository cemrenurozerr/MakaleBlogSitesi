using BlogSitesi.DAL;
using BlogSitesi.Models;
using BlogSitesi.ViewModels;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Text.Encodings.Web;

namespace BlogSitesi.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<Kullanici> _signInManager;
        private readonly UserManager<Kullanici> _userManager;
        private readonly BlogDBContext _dbContext;
        private readonly IEmailSender _emailSender;

        public LoginController(SignInManager<Kullanici> signInManager, UserManager<Kullanici> userManager, BlogDBContext dbContext, IEmailSender emailSender)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _dbContext = dbContext;
            _emailSender = emailSender;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            var kullanici = await _userManager.FindByEmailAsync(login.Email);

            if (kullanici == null || !await _userManager.CheckPasswordAsync(kullanici, login.Sifre))
            {
                ModelState.AddModelError("Hata", "Kullanıcı adı veya şifre yanlış...");
                return View(login);
            }

            await _signInManager.SignInAsync(kullanici, false);
            return RedirectToAction("Index", "Home");
        }

        
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/Login/Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            var usernames = _dbContext.Users.Select(x => x.Email).ToList();
            if (usernames.Contains(register.Email))
            {
                TempData["Hata"] = " Bu Email hesabı zaten kayıtlı.";
                return RedirectToAction("Register", "Login");
            }
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            if (ModelState.IsValid)
            {
                var user = new Kullanici { UserName = register.Email, Email = register.Email, Ad = register.Ad, Soyad = register.Soyad };
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, register.Sifre);
                var result = await _userManager.CreateAsync(user, register.Sifre);

                if (result.Succeeded)
                {

                    await _userManager.AddToRoleAsync(user, "Uye");
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Action(nameof(ConfirmEmail), "Login", new { userId = user.Id, code }, protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(register.Email, "Emailinizi doğrulayın",
                        $"Lütfen emailinizi doğrulamak için <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>buraya tıklayın</a>.");

                    //TempData["Mail"] = "Mailinize Gelen Doğrulama Linkini Onaylayın!";
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction("Register", "Login");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Kullanıcı ID '{userId}' bulunamadı.");
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }
    }
}

