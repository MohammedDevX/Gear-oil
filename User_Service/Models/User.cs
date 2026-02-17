namespace User_Service.Models
{
    public class User
    {

        public int Id { get; set; }

        public string Nom { get; set; }
        public string Prenom { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public int Role { get; set; } // yla kan 1 admin yla kan 2 client


    }
}
