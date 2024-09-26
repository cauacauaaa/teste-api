using CidadeInteligente.Data.Repository;
using CidadeInteligente.Models;
using System.Collections.Generic;

namespace CidadeInteligente.Services
{
    public class AcidenteService : IAcidenteService
    {
        private readonly IAcidenteRepository _acidenteRepository;

        public AcidenteService(IAcidenteRepository acidenteRepository)
        {
            _acidenteRepository = acidenteRepository;
        }

        public IEnumerable<AcidenteModel> ListarAcidentes()
        {
            return _acidenteRepository.GetAll();
        }

        public AcidenteModel ObterAcidentePorId(int id)
        {
            return _acidenteRepository.GetById(id);
        }

        public void CriarAcidente(AcidenteModel acidente)
        {
            _acidenteRepository.Add(acidente);
        }

        public void AtualizarAcidente(AcidenteModel acidente)
        {
            _acidenteRepository.Update(acidente);
        }

        public void DeletarAcidente(int id)
        {
            var acidente = _acidenteRepository.GetById(id);
            if (acidente != null)
            {
                _acidenteRepository.Delete(acidente);
            }
        }

        public IEnumerable<AcidenteModel> ListarAcidentes(int page, int size)
        {
            return _acidenteRepository.GetAll(page, size);
        }

        public IEnumerable<AcidenteModel> ListarAcidentesUltimaReferencia(int lastReference, int size)
        {
            return _acidenteRepository.GetAllReference(lastReference, size);
        }
    }
}
