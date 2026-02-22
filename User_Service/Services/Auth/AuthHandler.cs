using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using User_Service.DTOs.AuthDTOs;
using User_Service.Migrations;
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

        public async Task<bool> CheckExistingUser(ApplicationUser user, string role)
        {
            var search = await userManager.FindByEmailAsync(user.Email);

            if (search != null && await userManager.IsInRoleAsync(user, role))
            {
                return false;
            }

            await userManager.DeleteAsync(user);

            return true;
        }

        public async Task<bool> RegisterHandler(ApplicationUser user, string pass)
        {
            var res = await userManager.CreateAsync(user, pass);
            if (!res.Succeeded)
            {
                return false;
            }

            var roleRes = await userManager.AddToRoleAsync(user, "Client");
            if (!roleRes.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> RegisterAdminHandler(ApplicationUser user)
        {
            var res = await userManager.CreateAsync(user);
            if (!res.Succeeded)
            {
                return false;
            }

            var roleRes = await userManager.AddToRoleAsync(user, "Admin");
            if (!roleRes.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task<string> GenerateToken(ApplicationUser admin)
        {
            var token = await userManager.GenerateEmailConfirmationTokenAsync(admin);
            var encodedToken = WebEncoders.Base64UrlEncode(
                Encoding.UTF8.GetBytes(token));
            return encodedToken;
        }

        public async Task<bool> CheckeValidateToken(ApplicationUser user, string token)
        {
            var decodedToken = Encoding.UTF8.GetString(
                WebEncoders.Base64UrlDecode(token));

            var result = await userManager
                .ConfirmEmailAsync(user, decodedToken);
            if (!result.Succeeded)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> ActivateAdminAccount(ApplicationUser user, string pass)
        {
            user.IsActive = true;
            await userManager.AddPasswordAsync(user, pass);
            var updatedAdmin = await userManager.UpdateAsync(user);
            if (!updatedAdmin.Succeeded)
            {
                return false;
            }

            return true;
        }

        public async Task<ApplicationUser> FindAdmin(ActivateAdminDTO dto)
        {
            var admin = await userManager.FindByIdAsync(dto.UserId);
            return admin;
        }
    }
}
