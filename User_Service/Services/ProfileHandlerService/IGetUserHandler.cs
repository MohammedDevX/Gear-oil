using Microsoft.AspNetCore.Identity;
using User_Service.Models;

namespace User_Service.Services.ProfileHandlerService
{
    public interface IGetUserHandler
    {
        public Task<ApplicationUser> GetConnectedUser(object user);
    }
}
