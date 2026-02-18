//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;

//namespace User_Service.Data
//{
//    public class UserDbContextFactory
//        : IDesignTimeDbContextFactory<UserDbContext>
//    {
//        public UserDbContext CreateDbContext(string[] args)
//        {
//            var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();

//            optionsBuilder.UseSqlServer(
//                "Server=localhost,1434;Database=UserDb;User Id=sa;Password=Your_password123!;TrustServerCertificate=True;");

//            return new UserDbContext(optionsBuilder.Options);
//        }
//    }
//}
