using BL;
using Common.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExDyslex.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Stats(int? id)
        {
            var clients = await new ClientsBL().GetAllClients();
            var selectListClients = clients.Select(e => new SelectListItem() { Text = $"{e.LastName} {e.FirstName}", Value = e.Id.ToString() }).ToList();
            ViewBag.selectListClients = selectListClients;

            var tests = new TestsBL().GetAllTests();
            var selectListTests = tests.Select(e => new SelectListItem() { Text = $"{e.Name}", Value = e.Id.ToString() }).ToList();
            ViewBag.selectListTests = selectListTests;

            if (id != null)
            {
                ViewBag.idd = id;
            }
            return View();
        }

        public IActionResult Tests()
        {
            return View();
        }

        public IActionResult GetIdClient([FromBody]string id)
        {
            int iddd = int.Parse(id);

            return RedirectToAction("Stats", "Home", new { Area = "Admin", id = iddd});
        }
    }
}
