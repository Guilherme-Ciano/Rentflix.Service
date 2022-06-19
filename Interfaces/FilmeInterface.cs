using rentflix.service.Models;
namespace rentflix.service.Interfaces
{
    public interface FilmeInterface
    {
        Filme Get(int id);
        Filme Get(string nome);
        void Create(Filme filme);
        void Update(Filme filme);
        void Delete(int id);
        IEnumerable<Filme> GetAll();
        IEnumerable<Filme> GetById(int id);
        IEnumerable<Filme> GetByGenero(int id);
    }
}