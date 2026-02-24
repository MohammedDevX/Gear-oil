using User_Service.DTOs;
using User_Service.Models;

namespace User_Service.Mappings.Profile
{
    public class ProfileM
    {
        public static ApplicationUser ToApplicationUser(UpdateProfileDto dto)
        {
            return new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Nom = dto.Nom,
                Prenom = dto.Prenom
            };
        }
    }
}
