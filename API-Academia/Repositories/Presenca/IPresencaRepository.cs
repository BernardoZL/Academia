using API_Academia.BancoDados.Entidades;

namespace API_Academia.Repositories.Presenca
{
    public interface IPresencaRepository
    {
        public Task CadastrarPresenca(int pUsuario);
        public Task<List<PresencaEntidade>> BuscarAvaliacaoFisica(int pUsuario);
    }
}
