using CidadeInteligente.Models;

namespace CidadeInteligente.Services
{
    public interface IMonitorService
    {
        IEnumerable<MonitorModel> ListarMonitores();
        MonitorModel ObterMonitorPorId(int id);
        void CriarMonitor (MonitorModel monitor);
        void AtualizarMonitor (MonitorModel monitor);
        void DeletarMonitor(int id);
    }
}
