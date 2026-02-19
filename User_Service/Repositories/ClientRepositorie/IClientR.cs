using User_Service.Models;

namespace User_Service.Repositories.UserRepositorie
{
    public interface IClientR
    {
        public Task<List<User>> GetUsers();
        public Task<List<Client>> GetAll();
        public Task Add(User user);
    }
}
