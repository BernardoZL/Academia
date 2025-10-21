using API_Academia.Data.DTOs;

namespace API_Academia.Repositories.Treino
{
    public interface ITreinoRepository
    {
        public Task<TreinoDTO> CadastrarTreino(TreinoDTO pTreino);
        public Task<TreinoDTO> BuscarTreino(int pId);
        public Task<List<TreinoDTO>> BuscarListaTreinoAluno(int pIdAluno);
        public Task AtualizarTreino( TreinoDTO pTreino);
        public Task DeletarTreino(int pId);
    }
}
