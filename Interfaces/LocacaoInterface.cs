using rentflix.service.Models;
namespace rentflix.service.Interfaces
{
    public interface LocacaoInterface
    {
        void Create(Locacao locacao);
        void Update(Locacao locacao);
        void Delete(int id);
        Locacao GetById(int id);
        Locacao GetByClienteId(int id);
        Locacao GetByFilmeId(int id);
    }
}