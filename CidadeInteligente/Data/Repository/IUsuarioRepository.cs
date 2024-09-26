using CidadeInteligente.Models;
using System.Collections.Generic;

namespace CidadeInteligente.Data.Repository
{
    public interface IUsuarioRepository
    {
        IEnumerable<UsuarioModel> GetAll();
        UsuarioModel GetById(int id);
        void Add(UsuarioModel usuario);
        void Update(UsuarioModel usuario);
        void Delete(UsuarioModel usuario);

        IEnumerable<UsuarioModel> GetAll(int page, int size);
        IEnumerable<UsuarioModel> GetAllReference(int lastReference, int size);
    }
}
