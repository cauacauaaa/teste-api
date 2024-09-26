using CidadeInteligente.Models;

namespace CidadeInteligente.Services
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioModel> ListarUsuarios();
        UsuarioModel ObterUsuarioPorId(int id);
        void CriarUsuario(UsuarioModel usuario);
        void AtualizarUsuario(UsuarioModel usuario);
        void DeleterUsuario(int id);
    }
}
