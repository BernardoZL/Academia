using API_Academia.BancoDados;
using API_Academia.BancoDados.Entidades;
using API_Academia.Data.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Academia.Repositories.Treino
{
    public class TreinoRepository : ITreinoRepository
    {
        private readonly IMapper _Mapper;
        private readonly ContextoBancoDados _ContextoBancoDados;
        public TreinoRepository(IMapper mapper, ContextoBancoDados dbContext)
        {
            _Mapper = mapper;
            _ContextoBancoDados = dbContext;
        }

        public async Task<TreinoDTO> CadastrarTreino(TreinoDTO pTreino)
        {
            TreinoEntidade TreinoMapeada = _Mapper.Map<TreinoEntidade>(pTreino);

            _ContextoBancoDados.Treino.Add(TreinoMapeada);

            await _ContextoBancoDados.SaveChangesAsync();

            return _Mapper.Map<TreinoDTO>(TreinoMapeada);
        }

        public async Task<TreinoDTO> BuscarTreino(int pId)
        {
            TreinoEntidade TreinoBanco = await _ContextoBancoDados.Treino.Where(x => x.Id == pId).FirstOrDefaultAsync() ??
                                                    throw new Exception("Registro não encontrado");


            return _Mapper.Map<TreinoDTO>(TreinoBanco);
        }

        public async Task<List<TreinoDTO>> BuscarListaTreinoAluno(int pIdAluno)
        {
            return _Mapper.Map<List<TreinoDTO>>(await _ContextoBancoDados.Treino
                                                                        .Where(x => x.IdAluno == pIdAluno)
                                                                        .ToListAsync());
        }

        public async Task AtualizarTreino(TreinoDTO pTreino)
        {
            TreinoEntidade TreinoBanco = await _ContextoBancoDados.Treino.Where(x => x.Id == pTreino.Id).FirstOrDefaultAsync() ??
                                                    throw new Exception("Registro não encontrado");
            
            _Mapper.Map(pTreino, TreinoBanco);
            _ContextoBancoDados.Treino.Update(TreinoBanco);
            await _ContextoBancoDados.SaveChangesAsync();
        }

        public async Task DeletarTreino(int pId)
        {
            TreinoEntidade TreinoBanco = await _ContextoBancoDados.Treino.Where(x => x.Id == pId).FirstOrDefaultAsync() ??
                                                    throw new Exception("Registro não encontrado");
            _ContextoBancoDados.Treino.Remove(TreinoBanco);
            await _ContextoBancoDados.SaveChangesAsync();
        }
    }
}
