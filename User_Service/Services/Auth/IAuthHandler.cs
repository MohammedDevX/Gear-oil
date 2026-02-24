using User_Service.DTOs.AuthDTOs;
using User_Service.Models;

namespace User_Service.Services.Auth
{
    public interface IAuthHandler
    {
        public Task<bool> RegisterHandler(ApplicationUser user, string pass);
        public Task<bool> CheckExistingUser(ApplicationUser user, string role);
        public Task<bool> RegisterAdminHandler(ApplicationUser user);
        public Task<string> GenerateToken(ApplicationUser admin);
        public Task<bool> CheckeValidateToken(ApplicationUser user, string token);
        public Task<bool> ActivateAdminAccount(ApplicationUser user, string pass);
        public Task<ApplicationUser> FindAdmin(ActivateAdminDTO dto);
    }
}
