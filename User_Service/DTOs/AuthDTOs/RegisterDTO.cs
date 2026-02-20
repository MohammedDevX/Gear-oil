using System.ComponentModel.DataAnnotations;

namespace User_Service.DTOs.AuthDTOs
{
    public class RegisterDTO
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string User_name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        //[MinLength(6)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{6,}$", ErrorMessage = "Respecter les normes de mot passe")]
        public string Mot_passe { get; set; }
        [DataType(DataType.Password)]
        [Compare("Mot_passe")]
        public string Confirm_pass { get; set; }
    }
}
