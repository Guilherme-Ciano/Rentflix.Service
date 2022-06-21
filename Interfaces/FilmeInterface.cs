using rentflix.service.DTOs;
namespace rentflix.service.Interfaces
{
    public interface FilmeInterface
    {
        void Create(FilmeDTO filme);
        void Update(FilmeDTO filme);
        void Delete(int id);
        IEnumerable<FilmeDTO> GetAll();
        FilmeDTO GetById(int id);
    }
}