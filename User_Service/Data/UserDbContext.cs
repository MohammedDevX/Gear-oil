using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using User_Service.Models;

namespace User_Service.Data
{
    public class UserDbContext
        : IdentityDbContext<ApplicationUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }
    }
}