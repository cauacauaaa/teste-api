using CidadeInteligente.Models;

namespace CidadeInteligente.Services
{
    public interface ISemaforoService
    {
         IEnumerable<SemaforoModel> ListarSemaforos();
         SemaforoModel ObterSemaforoPorId (int id);
         void CriarSemaforo(SemaforoModel semaforo);
         void AtualizarSemaforo(SemaforoModel semaforo);
         void DeletarSemaforo(int id);
    }
}