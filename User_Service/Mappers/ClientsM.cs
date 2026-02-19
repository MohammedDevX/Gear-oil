using User_Service.DTOs;
using User_Service.Models;

namespace User_Service.Mappers
{
    public class ClientsM
    {
        public static List<ClientsDTO> ToClientsDTO(List<Client> clients)
        {
            List<ClientsDTO> allClients = new List<ClientsDTO>();

            foreach(Client client in clients)
            {
                ClientsDTO permClient = new ClientsDTO
                {
                    UserId = client.UserId,
                    Nom = client.User.Nom,
                    Prenom = client.User.Prenom,
                    NomUser = client.User.NomUser,
                    Email = client.User.Email,
                    Role = client.User.Role
                };

                allClients.Add(permClient);
            }

            return allClients;
        }
    }
}
