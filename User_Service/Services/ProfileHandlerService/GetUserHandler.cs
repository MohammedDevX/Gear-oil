using Microsoft.AspNetCore.Identity;
using User_Service.Models;

namespace User_Service.Services.ProfileHandlerService
{
    public class GetUserHandler : IGetUserHandler
    {
        private UserManager<ApplicationUser> _manager;
        public GetUserHandler(UserManager<ApplicationUser> _manager)
        {
            this._manager = _manager;
        }
        public async Task<ApplicationUser> GetConnectedUser(object user)
        {
            var check = await _manager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)user);
            return (ApplicationUser)check;
        }
    }
}
