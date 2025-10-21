using API_Academia.BancoDados;
using API_Academia.BancoDados.Entidades;
using API_Academia.Data.DTOs;
using API_Academia.Data.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Academia.Repositories.AvaliacaoFisica
{
    public class AvaliacaoFisicaRepository : IAvaliacaoFisicaRepository
    {
        private readonly IMapper _Mapper;
        private readonly ContextoBancoDados _ContextoBancoDados;
        public AvaliacaoFisicaRepository(IMapper mapper, ContextoBancoDados dbContext)
        {
            _Mapper = mapper;
            _ContextoBancoDados = dbContext;
        }

        public async Task<AvaliacaoFisicaDTO> CadastrarAvaliacaoFisica(AvaliacaoFisicaDTO pAvaliacaoFisica)
        {
            AvaliacaoFisicaEntidade AvaliacaoFisicaMapeada = _Mapper.Map<AvaliacaoFisicaEntidade>(pAvaliacaoFisica);

            _ContextoBancoDados.AvaliacaoFisica.Add(AvaliacaoFisicaMapeada);

            await _ContextoBancoDados.SaveChangesAsync();

            return _Mapper.Map<AvaliacaoFisicaDTO>(AvaliacaoFisicaMapeada);
        }

        public async Task<AvaliacaoFisicaDTO> BuscarAvaliacaoFisica(int pId)
        {
            AvaliacaoFisicaEntidade AvaliacaoFisicaBanco = await _ContextoBancoDados.AvaliacaoFisica.Where(x => x.Id == pId).FirstOrDefaultAsync() ??
                                                    throw new Exception("Registro não encontrado");


            return _Mapper.Map<AvaliacaoFisicaDTO>(AvaliacaoFisicaBanco);
        }

        public async Task<List<AvaliacaoFisicaDTO>> BuscarListaAvaliacaoFisicaAluno(int pIdAluno)
        {
            return _Mapper.Map<List<AvaliacaoFisicaDTO>>(await _ContextoBancoDados.AvaliacaoFisica
                                                                        .Where(x => x.IdAluno == pIdAluno)
                                                                        .ToListAsync());
        }

        public async Task AtualizarAvaliacaoFisica(AvaliacaoFisicaDTO pAvaliacaoFisica)
        {
            AvaliacaoFisicaEntidade AvaliacaoFisicaBanco = await _ContextoBancoDados.AvaliacaoFisica.Where(x => x.Id == pAvaliacaoFisica.Id).FirstOrDefaultAsync() ??
                                                    throw new Exception("Registro não encontrado");

            _Mapper.Map(pAvaliacaoFisica, AvaliacaoFisicaBanco);
            
            _ContextoBancoDados.AvaliacaoFisica.Update(AvaliacaoFisicaBanco);
            await _ContextoBancoDados.SaveChangesAsync();
        }

        public async Task DeletarAvaliacaoFisica(int pId)
        {
            AvaliacaoFisicaEntidade AvaliacaoFisicaBanco = await _ContextoBancoDados.AvaliacaoFisica.Where(x => x.Id == pId).FirstOrDefaultAsync() ??
                                                    throw new Exception("Registro não encontrado");
            _ContextoBancoDados.AvaliacaoFisica.Remove(AvaliacaoFisicaBanco);
            await _ContextoBancoDados.SaveChangesAsync();
        }   

    }
}
