using CidadeInteligente.Data.Contexts;
using CidadeInteligente.Models;

namespace CidadeInteligente.Data.Repository
{
    public class SemaforoRepository : ISemaforoRepository
    {
        private readonly DatabaseContext _context;
        public SemaforoRepository(DatabaseContext context){
            _context = context;
        }
        public IEnumerable<SemaforoModel> GetAll(){
            return _context.Semaforos.ToList();
        }
        public SemaforoModel GetById(int id){
            return _context.Semaforos.Find(id);
        }
        public void Add(SemaforoModel semaforo){
            _context.Semaforos.Add(semaforo);
            _context.SaveChanges();
        }
        public void Update(SemaforoModel semaforo){
            _context.Semaforos.Update(semaforo);
            _context.SaveChanges();
        }
        public void Delete(SemaforoModel semaforo){
            _context.Semaforos.Remove(semaforo);
            _context.SaveChanges();
        }
    }
}