using FotoBlog_24_01_2024.Data;
using FotoBlog_24_01_2024.Models;
using Microsoft.AspNetCore.Mvc;

namespace FotoBlog_24_01_2024.Controllers
{
    public class GonderilerController : Controller
    {
        private UygulamaDbContext _db;
        private IWebHostEnvironment _env;

        public GonderilerController(UygulamaDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public IActionResult Yeni()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Yeni(YeniGonderiViewModel yeniGonderiViewModel)
        {
            if (ModelState.IsValid)
            {
                //işlem
                string ext = Path.GetExtension(yeniGonderiViewModel.Resim.FileName);
                string yeniDosyaAd = Guid.NewGuid() + ext;
                string yol = Path.Combine(_env.WebRootPath, "img", "upload", yeniDosyaAd);

                using (var fs = new FileStream(yol, FileMode.CreateNew))
                {
                    yeniGonderiViewModel.Resim.CopyTo(fs);
                }
                _db.Gonderiler.Add(new Gonderi
                {
                    Baslik = yeniGonderiViewModel.Baslik,
                    ResimYolu = yeniDosyaAd
                });
                _db.SaveChanges();
                return RedirectToAction("Index", "Home", new { Sonuc = "Eklendi" });
            }

            return View();
        }
    }
}
