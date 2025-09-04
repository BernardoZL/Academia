using API_Academia.Data.DTOs;
using API_Academia.Repositories.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_Academia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _UsuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _UsuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario(CreateUserDto pUsuario)
        {
            try
            {
                if ( int.Parse(User.FindFirstValue("IdCargo") ?? "0") != 1)
                {
                    return Unauthorized("Sem permissão");
                }
                return Ok(await _UsuarioRepository.CadastrarUsuario(pUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
