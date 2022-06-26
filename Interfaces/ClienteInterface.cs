using rentflix.service.DTOs;
namespace rentflix.service.Interfaces
{
    public interface ClienteInterface
    {
        void Create(ClienteDTO Cliente);
        void Update(ClienteDTO Cliente);
        void Delete(int id);
        IEnumerable<ClienteDTO> GetAll();
        ClienteDTO GetById(int id);
        ClienteDTO GetClienteLogging(LoggingDTO login);
    }
}