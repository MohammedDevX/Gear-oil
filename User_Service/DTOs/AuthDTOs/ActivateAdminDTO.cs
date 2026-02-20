using System.ComponentModel.DataAnnotations;

namespace User_Service.DTOs.AuthDTOs
{
    public class ActivateAdminDTO
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{6,}$", ErrorMessage = "Respecter les normes de mot passe")]
        public string Mot_passe { get; set; }
        [Compare("Mot_passe")]
        public string Comfirmation_pass { get; set; }
    }
}
