using System.ComponentModel.DataAnnotations;

namespace User_Service.DTOs.AuthDTOs
{
    public class RegisterAdminDTO
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
