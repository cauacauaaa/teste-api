using CidadeInteligente.Data.Repository;
using CidadeInteligente.Models;

namespace CidadeInteligente.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository){
            _usuarioRepository = usuarioRepository;
        }
        public IEnumerable<UsuarioModel> ListarUsuarios() => _usuarioRepository.GetAll();
        public UsuarioModel ObterUsuarioPorId(int id)
        {
            return _usuarioRepository.GetById(id);
        }
        public void CriarUsuario(UsuarioModel usuario)
        {
            _usuarioRepository.Add(usuario);
        }
        public void AtualizarUsuario(UsuarioModel usuario)
        {
            _usuarioRepository.Update(usuario);
        }

        public void DeleterUsuario(int id)
        {
            var usuario = _usuarioRepository.GetById(id);
            _usuarioRepository.Delete(usuario);
        }



    }
}