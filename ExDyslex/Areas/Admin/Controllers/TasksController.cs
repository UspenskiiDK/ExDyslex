using BL;
using Microsoft.AspNetCore.Mvc;

namespace ExDyslex.Admin.Controllers
{
    [Area("Admin")]
    public class TasksController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var clients = await new ClientsBL().GetAllClients();

            return View(clients);
        }
    }
}
