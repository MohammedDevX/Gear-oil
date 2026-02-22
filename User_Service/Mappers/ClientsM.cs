using User_Service.DTOs;
using User_Service.Models;

namespace User_Service.Mappers
{
    public class ClientsM
    {
        public static List<ClientsDTO> ToClientsDTO(List<ApplicationUser> clients)
        {
            List<ClientsDTO> allClients = new List<ClientsDTO>();

            foreach (ApplicationUser client in clients)
            {
                ClientsDTO permClient = new ClientsDTO
                {
                    UserId = client.Id,
                    Nom = client.Nom,
                    Prenom = client.Prenom,
                    UserName = client.UserName,
                    Email = client.Email,
                    IsBlocled = (bool)client.IsBlocked
                };

                allClients.Add(permClient);
            }

            return allClients;
        }
    }
}
