using User_Service.Models;

namespace User_Service.Services.ProfileHandlerService
{
    public interface IProfileHanlder
    {
        public Task<bool> UpdateProfile(ApplicationUser user);
    }
}
