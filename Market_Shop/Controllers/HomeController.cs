using Market_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Market_Shop.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Manager()
        {
            return RedirectToAction("Index", "Managers");
        }

        public IActionResult Patners_type()
        {
            return RedirectToAction("Index", "Patners_type");
        }

        public IActionResult PartnerProduct()
        {
            return RedirectToAction("Index", "PartnerProducts");
        }

        public IActionResult Requst()
        {
            return RedirectToAction("Index", "Requsts");
        }

        public IActionResult Patners()
        {
            return RedirectToAction("Index", "Partners");
        }

        public IActionResult Product()
        {
            return RedirectToAction("Index", "Products");
        }

        public IActionResult Product_type()
        {
            return RedirectToAction("Index", "Product_type");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
