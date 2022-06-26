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

        [Required]
        public string Poster { get; set; }

        public FilmeDTO()
        {

        }

        public FilmeDTO(
            string titulo,
            string genero,
            string sinopse,
            int classificacaoIndicativa,
            int lancamento,
            string poster
        )
        {
            Titulo = titulo;
            Genero = genero;
            Sinopse = sinopse;
            ClassificacaoIndicativa = classificacaoIndicativa;
            Lancamento = lancamento;
            Poster = poster;
        }

        public FilmeDTO(
            int id,
            string titulo,
            string genero,
            string sinopse,
            int classificacaoIndicativa,
            int lancamento,
            string poster
        )
        {
            Id = id;
            Titulo = titulo;
            Genero = genero;
            Sinopse = sinopse;
            ClassificacaoIndicativa = classificacaoIndicativa;
            Lancamento = lancamento;
            Poster = poster;
        }
    }
}