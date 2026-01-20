using EchoPOS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EchoPOS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(); // Requires: Views/Home/Index.cshtml
        }

        public IActionResult Privacy()
        {
            return View(); // Requires: Views/Home/Privacy.cshtml
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
