using Microsoft.AspNetCore.Mvc;
using User_Service.Mappers;
using User_Service.Repositories.UserRepositorie;

namespace User_Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientR _client;
        public ClientController(IClientR client)
        {
            _client = client;
        }

        //[HttpGet]
        //public async Task<IActionResult> GetClients()
        //{
        //    var clients = await _client.GetAll();
        //    var allClients = ClientsM.ToClientsDTO(clients);
        //    return Ok(allClients);
        //}

        public async Task<IActionResult> BlockedChange()
        {

            return NoContent();
        }
    }
}
