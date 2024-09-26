using CidadeInteligente.Models;

namespace CidadeInteligente.Data.Repository
{
    public interface ISemaforoRepository
    {
         IEnumerable<SemaforoModel> GetAll();
        SemaforoModel GetById(int id);
        void Add (SemaforoModel semaforo);
        void Update (SemaforoModel semaforo);
        void Delete(SemaforoModel Semaforo);
    }
}