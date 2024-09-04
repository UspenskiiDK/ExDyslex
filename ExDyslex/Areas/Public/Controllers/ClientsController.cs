using BL;
using ExDyslex.Areas.Public.Models;
using ExDyslex.Public.Models;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ClientModel clientModel)
        {
            if (clientModel == null || !ModelState.IsValid)
                return BadRequest();

            var clientEntity = ClientModel.ConvertToEntity(clientModel);

            var hashPassword = Common.Helpers.GenerateHashPassword(clientModel.Password);

            if (clientEntity != null)
            {
                clientEntity.Password = hashPassword;
                await new ClientsBL().CreateClient(clientEntity);

                return RedirectToAction("Index", "Home");
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

        [Authorize]
        public async Task<IActionResult> PersonalCabinetIndex()
        {
            var jwtToken = "";

            if(HttpContext.Request.Cookies["efrD"] != null)
            {
                jwtToken = HttpContext.Request.Cookies["efrd"];
            }

            if (!string.IsNullOrWhiteSpace(jwtToken))
            {
                var isLoggedIn = int.TryParse(Common.Helpers.ValidateToken(jwtToken)?.FindFirst("clientId")?.Value, out int clientId);

                if (isLoggedIn)
                {
                    var client = await new ClientsBL().GetClientById(clientId);
                    if (client != null)
                    {
                        var clientModel = ClientModel.ConvertFromEntity(client);
                        var oldPassword = clientModel?.Password ?? "";
                        var personalCaninetModel = new PersonalCabinetViewModel
                        {
                            ClinetModel = clientModel,
                            OldPassword = oldPassword
                        };

                        return View(personalCaninetModel);
                    }
                    else
                    {
                        return StatusCode(404);
                    }
                }
                else
                {
                    return StatusCode(404);
                }
                
            }
            else
            {
                return StatusCode(500);
            }
        }

        [Authorize]
        public async Task<IActionResult> PersonalCabinetUpdate(PersonalCabinetViewModel pkModel)
        {
            if (pkModel == null || !ModelState.IsValid)
                return StatusCode(500);

            var client = await new ClientsBL().GetClientById(pkModel.ClinetModel.Id);
            var oldPassword = client.Password;

            var isPasswordCorrect = Common.Helpers.VerifyHashPassword(pkModel.OldPassword, oldPassword);
            if (!isPasswordCorrect)
                return StatusCode(500);

            var newPasswordHash = Common.Helpers.GenerateHashPassword(pkModel.ClinetModel.Password);
            pkModel.ClinetModel.Password = newPasswordHash;

            var clientEntity = ClientModel.ConvertToEntity(pkModel.ClinetModel);

            if (clientEntity != null)
            {
                await new ClientsBL().UpdateClient(clientEntity);
                return RedirectToAction("PersonalCabinetIndex", "Clients");
            }
            else
            {
                return StatusCode(500);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
