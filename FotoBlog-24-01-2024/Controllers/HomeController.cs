using FotoBlog_24_01_2024.Data;
using FotoBlog_24_01_2024.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FotoBlog_24_01_2024.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UygulamaDbContext _db;
        public HomeController(ILogger<HomeController> logger,UygulamaDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Gonderiler
                .OrderByDescending(x=>x.Id)
                .ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
