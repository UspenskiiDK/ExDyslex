using Microsoft.AspNetCore.Mvc;

namespace ExDyslex.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Stats()
        {
            return View();
        }

        public IActionResult Tests()
        {
            return View();
        }
    }
}
