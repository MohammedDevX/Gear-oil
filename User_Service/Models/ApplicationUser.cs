using Microsoft.AspNetCore.Identity;

namespace User_Service.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public bool IsBlocked { get; set; } = false;
    }
}
