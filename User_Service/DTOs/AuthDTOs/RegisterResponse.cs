namespace User_Service.DTOs.AuthDTOs
{
    public class RegisterResponse
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
