using CidadeInteligente.Data.Contexts;
using CidadeInteligente.Models;

namespace CidadeInteligente.Data.Repository
{
    public class ViolacaoRepository : IViolacaoRepository
    {
        private readonly DatabaseContext _context;
        public ViolacaoRepository(DatabaseContext context){
            _context = context;
        }
        public IEnumerable<ViolacaoModel> GetAll(){
            return _context.Violacoes.ToList();
        }
        public ViolacaoModel GetById(int id){
            return _context.Violacoes.Find(id);
        }
        public void Add(ViolacaoModel violacao){
            _context.Violacoes.Add(violacao);
            _context.SaveChanges();
        }
        public void Update(ViolacaoModel violacao){
            _context.Violacoes.Update(violacao);
            _context.SaveChanges();
        }
        public void Delete(ViolacaoModel violacao){
            _context.Violacoes.Remove(violacao);
            _context.SaveChanges();
        }
    }
}