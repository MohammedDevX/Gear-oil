using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using User_Service.Enums;

namespace User_Service.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NomUser { get; set; }
        public string Email { get; set; }
        public string Mot_de_passe { get; set; }
        public UserRole Role { get; set; }
        public Client Clients { get; set; }
        public Admin Admin { get; set; }
    }
}
