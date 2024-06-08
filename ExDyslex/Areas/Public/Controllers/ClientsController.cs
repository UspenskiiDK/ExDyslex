using BL;
using ExDyslex.Areas.Public.Models;
using ExDyslex.Public.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace ExDyslex.Public.Controllers
{
    [Area("Public")]
    public class ClientsController : Controller
    {
        private readonly ILogger<ClientsController> _logger;

        public ClientsController(ILogger<ClientsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterIndex()
        {
            return View();
        }

        public async Task<IActionResult> Register(ClientModel clientModel)
        {
            if (clientModel == null || !ModelState.IsValid)
                return BadRequest();

            var clientEntity = clientModel.ConvertToEntity(clientModel);

            var hashPassword = Common.Helpers.GenerateHashPassword(clientModel.Password);

            if (clientEntity != null)
            {
                clientEntity.Password = hashPassword;
                await new ClientsBL().CreateClient(clientEntity);

                return Ok();
            }
            else
            {
                return StatusCode(500);
            }
        }

        public async Task<IActionResult> Login(string email, string password)
        {
            var client = await new ClientsBL().GetClientByEmail(email);

            if (client == null)
                return StatusCode(404);

            var isVerified = Common.Helpers.VerifyHashPassword(password, client.Password);

            if (isVerified == false)
            {
                return StatusCode(500);
            }

            var jwtToken = Common.Helpers.GenerateJwtToken(client);

            HttpContext.Response.Cookies.Append("efrD", jwtToken);

            return RedirectToAction("Index", "Tests");
        }

        public IActionResult PersonalCabinet()
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
