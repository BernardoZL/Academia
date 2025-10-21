using API_Academia.Data.DTOs;
using API_Academia.Data.Models;

namespace API_Academia.Repositories.Usuario
{
    public interface IUsuarioRepository
    {
        public Task<UserDto> CadastrarUsuario(CreateUserDto pUsuario);
        public Task<UsuarioToken?> BuscarUsuarioLogin(LoginDTO pLogin);
        public Task<List<UserDto>> ListarAlunos();
    }
}
