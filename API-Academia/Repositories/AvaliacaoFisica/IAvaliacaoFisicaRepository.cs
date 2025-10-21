using API_Academia.BancoDados;
using API_Academia.BancoDados.Entidades;
using API_Academia.Data.DTOs;

namespace API_Academia.Repositories.AvaliacaoFisica
{
    public interface IAvaliacaoFisicaRepository
    {
        public Task<AvaliacaoFisicaDTO> CadastrarAvaliacaoFisica(AvaliacaoFisicaDTO pAvaliacaoFisica);
        public Task<AvaliacaoFisicaDTO> BuscarAvaliacaoFisica(int pId);
        public Task<List<AvaliacaoFisicaDTO>> BuscarListaAvaliacaoFisicaAluno(int pIdAluno);
        public Task AtualizarAvaliacaoFisica( AvaliacaoFisicaDTO pAvaliacaoFisica);
        public Task DeletarAvaliacaoFisica(int pId);

    }
}
