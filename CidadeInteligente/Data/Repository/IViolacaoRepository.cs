using CidadeInteligente.Models;

namespace CidadeInteligente.Data.Repository
{
    public interface IViolacaoRepository
    {
        IEnumerable<ViolacaoModel> GetAll();
        ViolacaoModel GetById(int id);
        void Add(ViolacaoModel violacao);
        void Update(ViolacaoModel violacao);
        void Delete(ViolacaoModel violacao);
    }
}