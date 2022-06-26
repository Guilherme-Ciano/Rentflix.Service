using System.ComponentModel.DataAnnotations;

namespace rentflix.service.DTOs
{
    public class LoggingDTO
    {
        public LoggingDTO(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [MaxLength(16)]
        public string Senha { get; set; }
    };
}