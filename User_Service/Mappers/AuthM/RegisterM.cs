using User_Service.DTOs.AuthDTOs;
using User_Service.Models;

namespace User_Service.Mappers.AuthM
{
    public class RegisterM
    {
        public static ApplicationUser ToApplicationUser(RegisterDTO dto)
        {
            return new ApplicationUser
            {
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                UserName = dto.User_name,
                Email = dto.Email,
                IsBlocked = false
            };
        }

        public static RegisterResponse ToRegisterResponse(ApplicationUser user)
        {
            return new RegisterResponse
            {
                Id = user.Id,
                Nom = user.Nom,
                Prenom = user.Prenom,
                UserName = user.UserName,
                Email = user.Email
            };
        }

        public static ApplicationUser FromDTOAdminToApplicationUser(RegisterAdminDTO dto)
        {
            return new ApplicationUser
            {
                Nom = dto.Nom,
                Prenom = dto.Prenom,
                Email = dto.Email,
                IsActive = false
            };
        }

        public static RegisterAdminResponse ToRegisterAdminResponse(ApplicationUser user)
        {
            return new RegisterAdminResponse
            {
                Id = user.Id,
                Nom = user.Nom,
                Prenom = user.Prenom,
                Email = user.Email
            };
        }

        //public static ApplicationUser MapPassword(PasswordComfirmationDTO dto)
        //{
        //    return new ApplicationUser
        //    {
        //        PasswordHash = dto.
        //    }
        //}
    }
}
