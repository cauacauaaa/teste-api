using CidadeInteligente.Models;
using System.Collections.Generic;

namespace CidadeInteligente.Services
{
    public interface IAcidenteService
    {
        IEnumerable<AcidenteModel> ListarAcidentes();
        AcidenteModel ObterAcidentePorId(int id);
        void CriarAcidente(AcidenteModel acidente);
        void AtualizarAcidente(AcidenteModel acidente);
        void DeletarAcidente(int id);

        IEnumerable<AcidenteModel> ListarAcidentes(int page, int size);
        IEnumerable<AcidenteModel> ListarAcidentesUltimaReferencia(int lastReference, int size);
    }
}
