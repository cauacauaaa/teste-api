using CidadeInteligente.Data.Contexts;
using CidadeInteligente.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CidadeInteligente.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DatabaseContext _context;

        public UsuarioRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<UsuarioModel> GetAll() => _context.Usuarios.ToList();

        public UsuarioModel GetById(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Add(UsuarioModel usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Update(UsuarioModel usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void Delete(UsuarioModel usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        public IEnumerable<UsuarioModel> GetAll(int page, int size)
        {
            return _context.Usuarios
                .Skip((page - 1) * size)
                .Take(size)
                .AsNoTracking()
                .ToList();
        }

        public IEnumerable<UsuarioModel> GetAllReference(int lastReference, int size)
        {
            return _context.Usuarios
                .Where(u => u.UsuarioId > lastReference)
                .OrderBy(u => u.UsuarioId)
                .Take(size)
                .AsNoTracking()
                .ToList();
        }
    }
}
