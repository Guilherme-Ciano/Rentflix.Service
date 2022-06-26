using System.ComponentModel.DataAnnotations;

namespace rentflix.service.DTOs
{
    public class ClienteDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [MaxLength(16)]
        public string Senha { get; set; }

        [Required]
        [MaxLength(11)]
        public string CPF { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        public ClienteDTO(
    string Nome,
    string CPF,
    DateTime DataNascimento, string Email, string Senha)
        {
            this.Nome = Nome;
            this.CPF = CPF;
            this.DataNascimento = DataNascimento;
            this.Email = Email;
            this.Senha = Senha;
        }

        public ClienteDTO(
            int id,
            string nome,
            string cpf,
            DateTime dataNascimento,
            string email,
            string senha
            )
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            DataNascimento = dataNascimento;
            Email = email;
            Senha = senha;
        }
    }
}