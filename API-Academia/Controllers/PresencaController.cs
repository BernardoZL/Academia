using API_Academia.Data.DTOs;
using API_Academia.Repositories.AvaliacaoFisica;
using API_Academia.Repositories.Presenca;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_Academia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PresencaController : ControllerBase
    {
        private readonly IPresencaRepository _PresencaRepository;

        public PresencaController(IPresencaRepository presencaRepository)
        {
            _PresencaRepository = presencaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarPresenca()
        {
            try
            {
                int IdUsuario = int.Parse(User.FindFirstValue("IdUsuario") ?? "0");
                await _PresencaRepository.CadastrarPresenca(IdUsuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet()]
        public async Task<IActionResult> BuscarPresenca()
        {
            try
            {
                int IdUsuario = int.Parse(User.FindFirstValue("IdUsuario") ?? "0");
                return Ok(await _PresencaRepository.BuscarAvaliacaoFisica(IdUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
