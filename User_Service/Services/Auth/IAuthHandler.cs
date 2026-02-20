using User_Service.Models;

namespace User_Service.Services.Auth
{
    public interface IAuthHandler
    {
        public Task<ApplicationUser> RegisterHandler(ApplicationUser user, string pass);
    }
}
