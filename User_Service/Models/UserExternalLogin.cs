namespace User_Service.Models
{
    public class UserExternalLogin
    {
        public int Id { get; set; }

        public string Provider { get; set; }
        // "google", "facebook", "instagram", "twitter"

        public string ProviderUserId { get; set; }
        // ID unique li rade yt3ta yla tar authontification b fb wla insta wla twiter...

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
