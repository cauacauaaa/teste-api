using CidadeInteligente.Data.Repository;
using CidadeInteligente.Models;

namespace CidadeInteligente.Services
{
    public class ViolacaoService : IViolacaoService
    {
        private readonly IViolacaoRepository _violacaoRepository;
        public ViolacaoService(IViolacaoRepository violacaoRepository){
            _violacaoRepository = violacaoRepository;
        }
        public IEnumerable<ViolacaoModel> ListarViolacaoes()
        {
            return _violacaoRepository.GetAll();
        }
        public ViolacaoModel ObterViolacaoPorId(int id)
        {
            return _violacaoRepository.GetById(id);
        }
        public void CriarViolacao(ViolacaoModel violacao)
        {
            _violacaoRepository.Add(violacao);
        }
        public void AtualizarViolacao(ViolacaoModel violacao)
        {
            _violacaoRepository.Update(violacao);
        }

        public void DeletarViolacao(int id)
        {
            var violacao = _violacaoRepository.GetById(id);
            _violacaoRepository.Delete(violacao);
        }



    }
}