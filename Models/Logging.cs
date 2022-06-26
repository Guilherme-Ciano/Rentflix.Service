namespace rentflix.service.Models
{
    public class Logging
    {
        public Logging(string email, string password)
        {
            this.Email = email;
            this.Senha = password;
        }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}