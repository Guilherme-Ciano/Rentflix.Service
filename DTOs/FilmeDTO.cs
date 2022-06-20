using System.ComponentModel.DataAnnotations;

namespace rentflix.service.DTOs
{
    public class FilmeDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Genero { get; set; }

        [Required]
        [MaxLength(500)]
        public string Sinopse { get; set; }

        [Required]
        public int ClassificacaoIndicativa { get; set; }

        [Required]
        public int Lancamento { get; set; }
    }
}