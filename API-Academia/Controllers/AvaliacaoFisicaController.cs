using API_Academia.Data.DTOs;
using API_Academia.Repositories.AvaliacaoFisica;
using API_Academia.Repositories.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_Academia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AvaliacaoFisicaController : ControllerBase
    {
        private readonly IAvaliacaoFisicaRepository _AvaliacaoFisicaRepository;

        public AvaliacaoFisicaController(IAvaliacaoFisicaRepository avaliacaoFisicaRepository)
        {
            _AvaliacaoFisicaRepository = avaliacaoFisicaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario([FromBody] AvaliacaoFisicaDTO pAvaliacaoFisica)
        {
            try
            {
                int idCargoLogado = int.Parse(User.FindFirstValue("IdCargo") ?? "0");
                if (idCargoLogado != 2 && idCargoLogado != 1)
                {
                    return Unauthorized("Sem permissão");
                }

                pAvaliacaoFisica.IdTreinador = int.Parse(User.FindFirstValue("IdUsuario") ?? "0");
                return Ok(await _AvaliacaoFisicaRepository.CadastrarAvaliacaoFisica(pAvaliacaoFisica));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{pId}")]
        public async Task<IActionResult> BuscarAvaliacaoFisica(int pId)
        {
            try
            {
                return Ok(await _AvaliacaoFisicaRepository.BuscarAvaliacaoFisica(pId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("ListarAvaliacaoFisicaAluno/{pIdAluno}")]
        public async Task<IActionResult> BuscarListaAvaliacaoFisicaAluno(int pIdAluno)
        {
            try
            {
                return Ok(await _AvaliacaoFisicaRepository.BuscarListaAvaliacaoFisicaAluno(pIdAluno));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> AtualizarAvaliacaoFisica([FromBody] AvaliacaoFisicaDTO pAvalicaoFisica)
        {
            try
            {
                await _AvaliacaoFisicaRepository.AtualizarAvaliacaoFisica( pAvalicaoFisica);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{pId}")]
        public async Task<IActionResult> DeletarAvaliacaoFisica(int pId)
        {
            try
            {
                await _AvaliacaoFisicaRepository.DeletarAvaliacaoFisica(pId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
