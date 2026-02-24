using Microsoft.AspNetCore.Mvc;
using User_Service.Mappers.ClientM;
using User_Service.Services.ClientsHandler;

namespace User_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientsHandler clientHandler;
        public ClientController( IClientsHandler clientHandler)
        {
            this.clientHandler = clientHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            
            var clients = await clientHandler.GetClients();
            var allClients = ClientsM.ToClientsDTO(clients);
            return Ok(allClients);
        }

        [HttpPatch("{id}")]
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
