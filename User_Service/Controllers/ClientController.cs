using Microsoft.AspNetCore.Mvc;
using User_Service.Mappers;
using User_Service.Repositories.UserRepositorie;
using User_Service.Services.ClientsHandler;

namespace User_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        //private IClientR _client;
        private IClientsHandler clientHandler;
        public ClientController( IClientsHandler clientHandler)
        {
            //_client = client;
            this.clientHandler = clientHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            
            var clients = await clientHandler.GetClients();
            var allClients = ClientsM.ToClientsDTO(clients);
            return Ok(allClients);
        }

        [HttpPatch]
        public async Task<IActionResult> BlockedChange(string id)
        {
            var check = await clientHandler.CheckExistingIdClient(id);
            if (check == null)
            {
                return NotFound();
            }

            var res = await clientHandler.BlcokedHandler(check);
            if (res == false)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
