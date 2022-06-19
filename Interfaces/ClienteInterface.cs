using rentflix.service.Models;
namespace rentflix.service.Interfaces
{
    public interface ClienteInterface
    {
        Cliente Get(int id);
        Cliente Get(string nome);
        void Create(Cliente Cliente);
        void Update(Cliente Cliente);
        void Delete(int id);
        IEnumerable<Cliente> GetAll();
        IEnumerable<Cliente> GetById(int id);
    }
}