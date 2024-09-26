using CidadeInteligente.Models;

namespace CidadeInteligente.Data.Repository
{
    public interface IMonitorRepository
    {
        IEnumerable<MonitorModel> GetAll();
        MonitorModel GetById(int id);
        void Add (MonitorModel monitor);
        void Update (MonitorModel monitor);
        void Delete(MonitorModel monitor);
    }
}