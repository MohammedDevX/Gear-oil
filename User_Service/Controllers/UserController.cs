using Microsoft.AspNetCore.Mvc;
using User_Service.Models;

namespace User_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        User user = new User()
        {
            UserId = 1,
            Nom = "Bakhtaoui",
            Prenom = "Mohammed",
            NomUser = "Mohammed12X",
            Email = "mohamed@gmail.com",
            Mot_de_passe = "12345",
            //Role = new Enums.UserRole.Admin,g
        };

        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("Hello from index");
        }
    }
}
