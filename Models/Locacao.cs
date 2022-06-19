namespace rentflix.service.Models
{
    public class Locacao
    {
        public Locacao(int id, int id_Cliente, int id_Filme, DateTime dataLocacao, DateTime dataDevolucao)
        {
            this.Id = id;
            this.Id_Cliente = id_Cliente;
            this.Id_Filme = id_Filme;
            this.DataLocacao = dataLocacao;
            this.DataDevolucao = dataDevolucao;

        }
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Filme { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataDevolucao { get; set; }
    }
}