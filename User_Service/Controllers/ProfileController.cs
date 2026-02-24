using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User_Service.DTOs;
using User_Service.Mappings.Profile;
using User_Service.Models;
using User_Service.Services.ProfileHandlerService;

namespace User_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IProfileHanlder _profile;
        public AuthController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IProfileHanlder _profile,
            IGetUserHandler getUserHandler)
        {
            _userManager = userManager;
            this._profile = _profile;
        }

        //la methode dyal modification de profil
        //[Authorize]
        [HttpPost("update-profile")]
        public async Task<IActionResult> UpdateProfile(UpdateProfileDto dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(422);
            }

            // Récupère l'utilisateur connecté via le token JWT
            //var user = await GetUserHandler.GetConnectedUser(User);

            //if (user == null)
            //    return Unauthorized();

            // Mise à jour partielle sécurisée
            //user.Nom = dto.Nom ?? user.Nom;
            //user.Prenom = dto.Prenom ?? user.Prenom;
            //user.Email = dto.Email ?? user.Email;
            //user.UserName = dto.UserName ?? user.UserName;
            var user = await _userManager.FindByEmailAsync(dto.Email);
            user = ProfileM.ToApplicationUser(dto);

            //var result = await _userManager.UpdateAsync(user);
            var result = _profile.UpdateProfile(user);
            if (result == null)
                return BadRequest();

            return NoContent();
        }
    }
}
