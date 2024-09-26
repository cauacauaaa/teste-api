using CidadeInteligente.Data.Repository;
using CidadeInteligente.Models;

namespace CidadeInteligente.Services
{
    public class MonitorService : IMonitorService
    {
        private readonly IMonitorRepository _monitorRepository;

        public MonitorService(IMonitorRepository monitorRepository){
            _monitorRepository = monitorRepository;
        }
        public IEnumerable<MonitorModel> ListarMonitores()
        {
            return _monitorRepository.GetAll();
        }
        public MonitorModel ObterMonitorPorId(int id)
        {
            return _monitorRepository.GetById(id);
        }
        public void CriarMonitor(MonitorModel monitor)
        {
            _monitorRepository.Add(monitor);
        }
        public void AtualizarMonitor(MonitorModel monitor)
        {
            _monitorRepository.Update(monitor);
        }


        public void DeletarMonitor(int id)
        {
            var monitor = _monitorRepository.GetById(id);
            _monitorRepository.Delete(monitor);
        }


    }
}