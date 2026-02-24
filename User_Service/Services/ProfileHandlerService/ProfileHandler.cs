using Microsoft.AspNetCore.Identity;
using User_Service.Models;

namespace User_Service.Services.ProfileHandlerService
{
    public class ProfileHandler : IProfileHanlder
    {
        private UserManager<ApplicationUser> _manager;
        public ProfileHandler(UserManager<ApplicationUser> _manager)
        {
            this._manager = _manager;
        }

        public async Task<bool> UpdateProfile(ApplicationUser user)
        {
            var result = await _manager.UpdateAsync(user);
            return result.Succeeded;
        } 
    }
}
