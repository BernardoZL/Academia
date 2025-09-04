using API_Academia.BancoDados.Entidades;
using API_Academia.BancoDados;
using AutoMapper;
using System.Security.Cryptography;
using API_Academia.Data.DTOs;
using Microsoft.EntityFrameworkCore;
using API_Academia.Data.Models;

namespace API_Academia.Repositories.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMapper _Mapper;
        private readonly ContextoBancoDados _ContextoBancoDados;
        public UsuarioRepository( IMapper mapper, ContextoBancoDados dbContext ) 
        {
            _Mapper = mapper;
            _ContextoBancoDados = dbContext;
        }

        public async Task<UserDto> CadastrarUsuario(CreateUserDto pUsuario)
        {
            UsuarioEntidade UsuarioMapeado = _Mapper.Map<UsuarioEntidade>(pUsuario);

            UsuarioMapeado.Senha = EncriptarSenha(UsuarioMapeado.Senha);

            _ContextoBancoDados.Usuario.Add(UsuarioMapeado);

            await _ContextoBancoDados.SaveChangesAsync();

            UsuarioMapeado = _ContextoBancoDados.Usuario.Include( x => x.Cargo ).First( x => x.Id == UsuarioMapeado.Id);

            return _Mapper.Map<UserDto>(UsuarioMapeado);
        }

        public async Task<UsuarioToken?> BuscarUsuarioLogin( LoginDTO pLogin )
        {
            UsuarioEntidade? UsuarioBanco = await _ContextoBancoDados.Usuario.Where( x => x.Nome == pLogin.Login ).FirstOrDefaultAsync();

            if( UsuarioBanco is null ) return null;

            if( VerificarSenhaInformada( pLogin.Senha, UsuarioBanco.Senha))
            {
                return _Mapper.Map<UsuarioToken>(UsuarioBanco);
            }

            return null;
        }

        //public async Task RedefinirSenha(int pId, string pSenha)
        //{
        //    UsuarioEntidade Usuario = await BuscarUsuario(pId);
        //    Usuario.Senha = EncriptarSenha(pSenha);

        //    _ContextoBancoDados.Usuario.Update(Usuario);

        //    await _ContextoBancoDados.SaveChangesAsync();
        //}

        private static string EncriptarSenha(string senha)
        {
            byte[] salt = new byte[16];
            using (var randomGenerator = RandomNumberGenerator.Create())
            {
                randomGenerator.GetBytes(salt);
            }
            var rfcPassword = new Rfc2898DeriveBytes(senha, salt, 1000, HashAlgorithmName.SHA1);
            byte[] rfcPasswordHash = rfcPassword.GetBytes(20);

            byte[] passwordHash = new byte[36];
            Array.Copy(salt, 0, passwordHash, 0, 16);
            Array.Copy(rfcPasswordHash, 0, passwordHash, 16, 20);
            return Convert.ToBase64String(passwordHash);
        }

        private static bool VerificarSenhaInformada(string senhaInformada, string senhaBanco)
        {
            byte[] dbPasswordHash = Convert.FromBase64String(senhaBanco);
            byte[] salt = new byte[16];
            Array.Copy(dbPasswordHash, 0, salt, 0, 16);
            var rfcPassword = new Rfc2898DeriveBytes(senhaInformada, salt, 1000, HashAlgorithmName.SHA1);
            byte[] rfcPasswordHash = rfcPassword.GetBytes(20);
            for (int i = 0; i < rfcPasswordHash.Length; i++)
            {
                if (dbPasswordHash[i + 16] != rfcPasswordHash[i])
                    return false;
            }
            return true;
        }
    }
}
