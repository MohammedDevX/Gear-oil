using User_Service.Enums;
using User_Service.Models;

public abstract class User
{
    public int Id { get; set; }

    public string Nom { get; set; }
    public string Prenom { get; set; }

    public string Username { get; set; }
    public string Email { get; set; }

    public string PasswordHash { get; set; } 

    public UserRole Role { get; set; } // 1 = Admin, 2 = Client hade rade tzad f l enum

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // hade 3la hssab les api nta3 l'authentification nta3 fb,twit,google..
    public ICollection<UserExternalLogin> ExternalLogins { get; set; }
}
