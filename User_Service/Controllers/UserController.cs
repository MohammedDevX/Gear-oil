using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace User_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("Hello from index");
        }
    }
}
