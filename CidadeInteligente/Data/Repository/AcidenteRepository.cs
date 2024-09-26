using CidadeInteligente.Data.Contexts;
using CidadeInteligente.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CidadeInteligente.Data.Repository
{
    public class AcidenteRepository : IAcidenteRepository
    {
        private readonly DatabaseContext _context;

        public AcidenteRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<AcidenteModel> GetAll() => _context.Acidentes.ToList();

        public AcidenteModel GetById(int id)
        {
            return _context.Acidentes.Find(id);
        }

        public void Add(AcidenteModel acidente)
        {
            _context.Acidentes.Add(acidente);
            _context.SaveChanges();
        }

        public void Update(AcidenteModel acidente)
        {
            _context.Acidentes.Update(acidente);
            _context.SaveChanges();
        }

        public void Delete(AcidenteModel acidente)
        {
            _context.Acidentes.Remove(acidente);
            _context.SaveChanges();
        }

        public IEnumerable<AcidenteModel> GetAll(int page, int size)
        {
            return _context.Acidentes
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<AcidenteModel> GetAllReference(int lastReference, int size)
        {
            return _context.Acidentes
                .Where(a => a.AcidenteId > lastReference)
                .OrderBy(a => a.AcidenteId)
                .Take(size)
                .AsNoTracking()
                .ToList();
        }
    }
}
