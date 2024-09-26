using System.Net.Mail;
using CidadeInteligente.Data.Repository;
using CidadeInteligente.Models;

namespace CidadeInteligente.Services
{
    public class SemaforoService : ISemaforoService
    {
        private readonly ISemaforoRepository _semaforoRepository;
        public SemaforoService(ISemaforoRepository semaforoRepository){
            _semaforoRepository = semaforoRepository;
        }
        public IEnumerable<SemaforoModel> ListarSemaforos()
        {
            return _semaforoRepository.GetAll();
        }
        public SemaforoModel ObterSemaforoPorId(int id)
        {
            return _semaforoRepository.GetById(id);
        }
        public void CriarSemaforo(SemaforoModel semaforo)
        {
            _semaforoRepository.Add(semaforo);
        }
        public void AtualizarSemaforo(SemaforoModel semaforo)
        {
            _semaforoRepository.Update(semaforo);
        }


        public void DeletarSemaforo(int id)
        {
            var semaforo = _semaforoRepository.GetById(id);
            _semaforoRepository.Delete(semaforo);
        }



    }
}