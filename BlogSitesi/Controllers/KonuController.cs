using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogSitesi.DAL;
using BlogSitesi.Models;
using Microsoft.AspNetCore.Identity;

namespace BlogSitesi.Controllers
{
    public class KonuController : Controller
    {
        private readonly BlogDBContext _context;
        private readonly UserManager<Kullanici> _userManager;

        public KonuController(BlogDBContext context, UserManager<Kullanici> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        // GET: Konus
        public async Task<IActionResult> Index()
        {
            // Tüm kategorileri ve ilgili makaleleri çekiyoruz
            var categories = _context.Konular
                .Include(c => c.MakaleKonular)
                    .ThenInclude(ac => ac.Makale)
                        .ThenInclude(a => a.Kullanici)
                .ToList();

            return View(categories);
        }

        // GET: Konus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konu = await _context.Konular
                .FirstOrDefaultAsync(m => m.KonuID == id);
            if (konu == null)
            {
                return NotFound();
            }

            return View(konu);
        }

        // GET: Konus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Konus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KonuID,Adi")] Konu konu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(konu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(konu);
        }

        // GET: Konus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konu = await _context.Konular.FindAsync(id);
            if (konu == null)
            {
                return NotFound();
            }
            return View(konu);
        }

        // POST: Konus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KonuID,Adi")] Konu konu)
        {
            if (id != konu.KonuID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(konu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KonuExists(konu.KonuID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(konu);
        }

        // GET: Konus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konu = await _context.Konular
                .FirstOrDefaultAsync(m => m.KonuID == id);
            if (konu == null)
            {
                return NotFound();
            }

            return View(konu);
        }

        // POST: Konus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var konu = await _context.Konular.FindAsync(id);
            if (konu != null)
            {
                _context.Konular.Remove(konu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult KonuTakip(int id)
        {
            KullaniciKonu followedTopic = _context.KullaniciKonular.FirstOrDefault(x => x.KonuID == id && x.KullaniciID == GetUserID());
            if (followedTopic == null)
            {
                KullaniciKonu kullaniciKonu = new KullaniciKonu();
                kullaniciKonu.KonuID = id;
                kullaniciKonu.KullaniciID = GetUserID();
                _context.KullaniciKonular.Add(kullaniciKonu);
                _context.SaveChanges();
                TempData["Success"] = "Konu Takip Edilmiştir";
                return RedirectToAction("Index", "Konu");
            }
            else
            {
                TempData["Hata"] = "Bu konu zaten takip ediliyor!";
                return RedirectToAction("Index", "Konu");
            }


            
        }
        private bool KonuExists(int id)
        {
            return _context.Konular.Any(e => e.KonuID == id);
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
