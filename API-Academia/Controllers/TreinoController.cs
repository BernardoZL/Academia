using API_Academia.Data.DTOs;
using API_Academia.Repositories.Treino;
using API_Academia.Repositories.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_Academia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TreinoController : ControllerBase
    {
        private readonly ITreinoRepository _TreinoRepository;

        public TreinoController(ITreinoRepository TreinoRepository)
        {
            _TreinoRepository = TreinoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarTreino([FromBody] TreinoDTO pTreino)
        {
            try
            {
                int idCargoLogado = int.Parse(User.FindFirstValue("IdCargo") ?? "0");
                if (idCargoLogado != 2 && idCargoLogado != 1)
                {
                    return Unauthorized("Sem permissão");
                }

                pTreino.IdTreinador = int.Parse(User.FindFirstValue("IdUsuario") ?? "0");
                return Ok(await _TreinoRepository.CadastrarTreino(pTreino));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{pId}")]
        public async Task<IActionResult> BuscarTreino(int pId)
        {
            try
            {
                return Ok(await _TreinoRepository.BuscarTreino(pId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("ListarTreinoAluno/{pIdAluno}")]
        public async Task<IActionResult> BuscarListaTreinoAluno(int pIdAluno)
        {
            try
            {
                return Ok(await _TreinoRepository.BuscarListaTreinoAluno(pIdAluno));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut]
        public async Task<IActionResult> AtualizarTreino( [FromBody] TreinoDTO pAvalicaoFisica)
        {
            try
            {
                await _TreinoRepository.AtualizarTreino(pAvalicaoFisica);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{pId}")]
        public async Task<IActionResult> DeletarTreino(int pId)
        {
            try
            {
                await _TreinoRepository.DeletarTreino(pId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
