using User_Service.Models;

namespace User_Service.Services.ClientsHandler
{
    public interface IClientsHandler
    {
        public Task<List<ApplicationUser>> GetClients();
        public Task<ApplicationUser> CheckExistingIdClient(string id);
        public Task<bool> BlcokedHandler(ApplicationUser client);
    }
}
