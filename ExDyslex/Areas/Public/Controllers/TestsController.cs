using BL;
using ExDyslex.Areas.Public.Models;
using ExDyslex.Public.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExDyslex.Public.Controllers
{
    [Area("Public")]
    [Authorize]
    public class TestsController : Controller
    {
        private readonly ILogger<TestsController> _logger;

        public TestsController(ILogger<TestsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var tests = new TestsBL().GetAllTests();

            var testsModel = tests.Select(item => TestModel.ConvertFromEntity(item)).ToList();

            return View(testsModel);
        }

        public IActionResult Test(int id)
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
