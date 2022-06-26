using rentflix.service.DTOs;
namespace rentflix.service.Interfaces
{
    public interface ClienteInterface
    {
        void Create(ClienteDTO Cliente);
        void Update(ClienteDTO Cliente);
        void Delete(ClienteDTO Cliente);
        IEnumerable<ClienteDTO> GetAll();
        ClienteDTO GetById(int id);
        ClienteDTO GetClienteLogging(LoggingDTO login);
    }
}