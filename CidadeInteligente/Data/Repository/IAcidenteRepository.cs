using CidadeInteligente.Models;
using System.Collections.Generic;

namespace CidadeInteligente.Data.Repository
{
    public interface IAcidenteRepository
    {
        IEnumerable<AcidenteModel> GetAll();
        AcidenteModel GetById(int id);
        void Add(AcidenteModel acidente);
        void Update(AcidenteModel acidente);
        void Delete(AcidenteModel acidente);

        IEnumerable<AcidenteModel> GetAll(int page, int size);
        IEnumerable<AcidenteModel> GetAllReference(int lastReference, int size);
    }
}
