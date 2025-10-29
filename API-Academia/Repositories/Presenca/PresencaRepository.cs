using API_Academia.BancoDados;
using API_Academia.BancoDados.Entidades;
using API_Academia.Data.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_Academia.Repositories.Presenca
{
    public class PresencaRepository : IPresencaRepository
    {
        private readonly ContextoBancoDados _ContextoBancoDados;
        public PresencaRepository(ContextoBancoDados dbContext)
        {

            _ContextoBancoDados = dbContext;
        }

        public async Task CadastrarPresenca(int pUsuario)
        {
            PresencaEntidade presenca = new PresencaEntidade()
            {
               IdUsuario = pUsuario,
               Data = DateTime.Now
            };

            _ContextoBancoDados.Presenca.Add(presenca);

            await _ContextoBancoDados.SaveChangesAsync();
        }

        public async Task<List<PresencaEntidade>> BuscarAvaliacaoFisica(int pUsuario)
        {
            return await _ContextoBancoDados.Presenca.Where( x => x.IdUsuario == pUsuario).ToListAsync();
        }
    }
}
