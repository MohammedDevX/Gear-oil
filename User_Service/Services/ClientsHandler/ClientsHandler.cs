using Microsoft.AspNetCore.Identity;
using User_Service.Models;

namespace User_Service.Services.ClientsHandler
{
    public class ClientsHandler : IClientsHandler
    {
        private UserManager<ApplicationUser> userManager;
        public ClientsHandler(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<List<ApplicationUser>> GetClients()
        {
             List<ApplicationUser> clients = (List<ApplicationUser>)await userManager.GetUsersInRoleAsync("Client");
            return clients;
        }

        public async Task<ApplicationUser> CheckExistingIdClient(string id)
        {
            var check = await userManager.FindByIdAsync(id);
            return check; 
            //if (check == null)
            //{
            //    return false;
            //}

            //return true;
        }

        public async Task<bool> BlcokedHandler(ApplicationUser client)
        {
            client.IsBlocked = !client.IsBlocked;
            var res = await userManager.UpdateAsync(client);
            return res.Succeeded;
            //if (!res.Succeeded)
            //{
            //    return false;
            //}

            //return true;
        }
    }
}
