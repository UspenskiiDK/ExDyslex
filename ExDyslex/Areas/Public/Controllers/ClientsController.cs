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

        public async Task<IActionResult> Register(/*ClientModel clientModel*/)
        {
            var clientModel = new ClientModel(0, "Дмитрий", "Успенский", null,
                new DateTime(1999, 10, 17), "+79518882988", "uspenskiidk@gmail.com", "pass", null);

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

        public async Task<string> Login(/*string email, string password*/)
        {
            var email = "uspenskiidk@gmail.com";
            var password = "pass";
            var client = await new ClientsBL().GetClientByEmail(email);

            if (client == null)
                return "Пользователь не найден";

            var isVerified = Common.Helpers.VerifyHashPassword(password, client.Password);

            if (isVerified == false)
            {
                return "Неверный пароль";
            }

            var jwtToken = Common.Helpers.GenerateJwtToken(client);

            HttpContext.Response.Cookies.Append("efrD", jwtToken);

            return jwtToken;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
