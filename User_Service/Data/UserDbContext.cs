using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using User_Service.Models;

namespace User_Service.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options): base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.NomUser, u.Email })
                .IsUnique();
        }
    }
}
