//using User_Service.Enums;

using System.Security.Principal;

namespace User_Service.DTOs
{
    public class ClientsDTO
    {
        public string UserId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsBlocled { get; set; }
    }
}
