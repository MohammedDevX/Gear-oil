using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using User_Service.Data;
using User_Service.DTOs;
using User_Service.Models;

namespace User_Service.Repositories.UserRepositorie
{
    public class ClientR 
    {
        private UserDbContext context;
        public ClientR(UserDbContext context)
        {
            this.context = context;
        }

        //public async Task<List<Client>> GetAll()
        //{
        //    var clients = await context.Clients.Include(u => u.User).ToListAsync();
        //    return clients;
        //}

        //public async Task BlockedChange()
        //{
        //    context.Clients.Update()
        //}
    }
}
