using User_Service.Enums;

namespace User_Service.DTOs
{
    public class ClientsDTO
    {
        public int UserId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string NomUser { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
}
