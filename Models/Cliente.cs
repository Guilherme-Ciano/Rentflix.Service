namespace rentflix.service.Models
{
    public class Cliente
    {
        public Cliente(int id, string nome, string cpf, DateTime dataNascimento)
        {
            this.Id = id;
            this.Nome = nome;
            this.CPF = cpf;
            this.DataNascimento = dataNascimento;
        }

        public Cliente(string nome, string cpf, DateTime dataNascimento)
        {
            this.Nome = nome;
            this.CPF = cpf;
            this.DataNascimento = dataNascimento;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }

    }
}