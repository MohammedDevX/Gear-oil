using Microsoft.AspNetCore.Identity;
using User_Service.Models;

namespace User_Service.Services.Auth
{
    public class AuthHandler : IAuthHandler
    {
        private UserManager<ApplicationUser> userManager;
        
        public AuthHandler(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<bool> RegisterHandler(ApplicationUser user, string pass)
        {
            var getClients = await userManager.GetUsersInRoleAsync("Client");
            var search = getClients.Any(c => c.Email == user.Email || c.UserName == user.UserName);
            
            if (search == true)
            {
                return false;
            }

            var res = await userManager.CreateAsync(user, pass);
            if (!res.Succeeded)
            {
                throw new Exception("Error creation user");
            }

            await userManager.AddToRoleAsync(user, "Client");
            return true;
        }

        public async Task<bool> RegisterAdminHandler(ApplicationUser user)
        {
            var getClients = await userManager.GetUsersInRoleAsync("Admin");
            var search = getClients.Any(c => c.Email == user.Email);

            if (search == true)
            {
                return false;
            }

            var res = await userManager.CreateAsync(user);
            if (!res.Succeeded)
            {
                throw new Exception("Error creation user");
            }

            await userManager.AddToRoleAsync(user, "Admin");
            return true;
        }

        public async Task<string> GenerateToken(ApplicationUser admin)
        {
            var token = await userManager.GenerateEmailConfirmationTokenAsync(admin);
            return token;
        }

        public async Task AddHashedPasswordToActivatedAdmin()
        {

        } 
    }
}
