using CidadeInteligente.Models;

namespace CidadeInteligente.Services {
        public interface IAuthService
        {
            UserModel Authenticate(string username, string password);
        }
    }

