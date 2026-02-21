using User_Service.DTOs;
using User_Service.Models;

namespace User_Service.Mappings
{
    public static class UserMapping
    {
        public static ApplicationUser ToClientUser(RegisterClientDto dto)
        {
            return new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                Nom = dto.Nom,
                Prenom = dto.Prenom
            };
        }

        public static ApplicationUser ToAdminUser(CreateAdminDto dto)
        {
            return new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email
            };
        }
    }
}