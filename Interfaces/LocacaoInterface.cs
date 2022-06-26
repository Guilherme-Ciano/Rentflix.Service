using rentflix.service.DTOs;
namespace rentflix.service.Interfaces
{
    public interface LocacaoInterface
    {
        List<LocacaoDTO> GetAll();
        void Create(LocacaoDTO locacao);
        void Update(LocacaoDTO locacao);
        void Delete(int id);
        LocacaoDTO GetById(int id);
        LocacaoDTO GetByClienteId(int id);
        LocacaoDTO GetByFilmeId(int id);
    }
}