using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using S8_Complet.Models;
using System.Diagnostics;

namespace S8_Complet.Controllers
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
            if (this.HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("RespoHome");
            else
                return View();
        }

        /*[Authorize(Roles ="Admin")]*/
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult RespoHome()
        {
            return View();
        }

        public IActionResult Prediction()
        {
            PredictionItem pred = new PredictionItem();
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}