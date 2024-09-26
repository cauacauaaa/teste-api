using CidadeInteligente.Data.Contexts;
using CidadeInteligente.Models;

namespace CidadeInteligente.Data.Repository
{
    public class MonitorRepository : IMonitorRepository
    {
        private readonly DatabaseContext _context;
        public MonitorRepository(DatabaseContext context){
            _context = context;
        }
        public IEnumerable<MonitorModel> GetAll(){
            return _context.Monitores.ToList();
        }
        public MonitorModel GetById(int id){
            return _context.Monitores.Find(id);
        }
        public void Add(MonitorModel monitor){
            _context.Monitores.Add(monitor);
            _context.SaveChanges();
        }
        public void Update(MonitorModel monitor){
            _context.Monitores.Update(monitor);
            _context.SaveChanges();
        }
        public void Delete(MonitorModel monitor){
            _context.Monitores.Remove(monitor);
            _context.SaveChanges();
        }
    }
}