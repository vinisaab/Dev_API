using Dev_API.Dominio.Entidade;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Utilitario.JWT;

namespace Dev_API.Negocio.JWT
{
    public static class JwtServico
    {
        public static Tuple<string, DateTime> GerarToken(Usuario usuario)
        {
            var tokenHadler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtSecret.SecretKey);

            var expiracao = DateTime.UtcNow.AddHours(1);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.LoginDoUsuario),
                    new Claim(ClaimTypes.Email, usuario.EmailDoUsuario)
                }),
                Expires = expiracao,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHadler.CreateToken(tokenDescriptor);
            
            return new Tuple<string, DateTime>(tokenHadler.WriteToken(token), expiracao); ;
        }
    }
}
