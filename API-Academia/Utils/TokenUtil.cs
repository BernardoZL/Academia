using API_Academia.Data.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

namespace API_Academia.Utils
{
    public static class TokenUtil
    {
        public static string Key = "1c656e630da823594db9a66e9c1e33c096cf5221a1cb61129281292e1b5b6508";
        public static string GerarToken(UsuarioToken pUsuario)
        {
            byte[] chave = Encoding.ASCII.GetBytes(Key);

            SecurityTokenDescriptor config = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                [
                    new Claim("IdUsuario", pUsuario.Id.ToString()),
                    new Claim("IdCargo", pUsuario.IdCargo.ToString()),
                    new Claim("Nome", pUsuario.Nome)
                ]),

                Expires = DateTime.UtcNow.AddHours(18),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            SecurityToken token = handler.CreateToken(config);
            string stringToken = handler.WriteToken(token);

            return stringToken;

        }
    }
}
