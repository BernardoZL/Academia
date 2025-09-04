using API_Academia.Data.DTOs;
using API_Academia.Data.Models;
using API_Academia.Repositories.Usuario;
using API_Academia.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Academia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController: ControllerBase
    {
        private readonly IUsuarioRepository _UsuarioRepository;

        public AccountController( IUsuarioRepository usuarioRepository )
        {
            _UsuarioRepository = usuarioRepository;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO pLogin)
        {
            try
            {
                UsuarioToken? Usuario = await _UsuarioRepository.BuscarUsuarioLogin(pLogin);

                if ( Usuario is null )
                    return Unauthorized("Usuário ou senha inválidos.");

                string Token = TokenUtil.GerarToken(Usuario);

                return Ok(Token);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = ex.Message });
            }
        }


    }
}
