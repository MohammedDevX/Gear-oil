using System.ComponentModel.DataAnnotations.Schema;

namespace User_Service.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public bool Blocked { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
