using User_Service.Models;

namespace User_Service.Repositories.UserRepositorie
{
    public interface IClientR
    {
        public Task<List<ApplicationUser>> GetAll();
        public Task BlockedChange();
    }
}
