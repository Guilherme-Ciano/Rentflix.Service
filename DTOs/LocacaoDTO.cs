using System.ComponentModel.DataAnnotations;

namespace rentflix.service.DTOs
{
    public class LocacaoDTO
    {
        public LocacaoDTO(int id, int id_Cliente, int id_Filme, DateTime dataLocacao, DateTime dataDevolucao)
        {
            Id = id;
            Id_Cliente = id_Cliente;
            Id_Filme = id_Filme;
            DataLocacao = dataLocacao;
            DataDevolucao = dataDevolucao;
        }

        public LocacaoDTO(int id_Cliente, int id_Filme, DateTime dataLocacao, DateTime dataDevolucao)
        {
            Id_Cliente = id_Cliente;
            Id_Filme = id_Filme;
            DataLocacao = dataLocacao;
            DataDevolucao = dataDevolucao;
        }

        public LocacaoDTO() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public int Id_Cliente { get; set; }

        [Required]
        public int Id_Filme { get; set; }

        [Required]
        public DateTime DataLocacao { get; set; }

        [Required]
        public DateTime DataDevolucao { get; set; }

    }
}