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
    }
}
