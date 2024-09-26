using CidadeInteligente.Models;

namespace CidadeInteligente.Services
{
    public interface IViolacaoService
    {
        IEnumerable<ViolacaoModel> ListarViolacaoes();
        ViolacaoModel ObterViolacaoPorId(int id);
        void CriarViolacao(ViolacaoModel violacao);
        void AtualizarViolacao(ViolacaoModel violacao);
        void DeletarViolacao(int id);
    }
}
