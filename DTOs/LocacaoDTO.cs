using System.ComponentModel.DataAnnotations;

namespace rentflix.service.DTOs
{
    public class LocacaoDTO
    {
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