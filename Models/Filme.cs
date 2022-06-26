namespace rentflix.service.Models
{
    public class Filme
    {

        public Filme(int id, string titulo, string genero, string sinopse, string poster, int classificacaoIndicativa, int lancamento)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Genero = genero;
            this.Sinopse = sinopse;
            this.ClassificacaoIndicativa = classificacaoIndicativa;
            this.Lancamento = lancamento;
            this.Poster = poster;

        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public string Sinopse { get; set; }
        public int ClassificacaoIndicativa { get; set; }
        public int Lancamento { get; set; }
        public string Poster { get; set; }
    }
}