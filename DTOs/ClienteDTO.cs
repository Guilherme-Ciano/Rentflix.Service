using System.ComponentModel.DataAnnotations;

namespace rentflix.service.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(11)]
        public string CPF { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }
    }
}