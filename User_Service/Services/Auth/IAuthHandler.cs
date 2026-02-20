using User_Service.Models;

namespace User_Service.Services.Auth
{
    public interface IAuthHandler
    {
        public Task<bool> RegisterHandler(ApplicationUser user, string pass);
        public Task<bool> RegisterAdminHandler(ApplicationUser user);
        public Task<string> GenerateToken(ApplicationUser admin);
    }
}
