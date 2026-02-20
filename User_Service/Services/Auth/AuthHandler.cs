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

        public async Task<ApplicationUser> RegisterHandler(ApplicationUser user, string pass)
        {
            var res = await userManager.CreateAsync(user, pass);
            if (!res.Succeeded)
            {
                throw new Exception("Error creation user");
            }

            await userManager.AddToRoleAsync(user, "Client");
            return user;
        }
    }
}
