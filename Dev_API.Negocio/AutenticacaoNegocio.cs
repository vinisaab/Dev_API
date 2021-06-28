using Dev_API.Dominio.Entidade;
using Dev_API.Dominio.Interfaces.Negocio;
using Dev_API.Dominio.Interfaces.Repositório;
using Dev_API.Negocio.JWT;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev_API.Negocio
{
    public class AutenticacaoNegocio : IAutenticacaoNegocio
    {

        private readonly IAutenticacaoRepositorio _autenticacaoRepositorio;
        public AutenticacaoNegocio(IAutenticacaoRepositorio autenticacaoRepositorio)
        {
            _autenticacaoRepositorio = autenticacaoRepositorio;
        }
        public Tuple<string, DateTime> Login(Usuario usuario)
        {
            bool usuarioLogado =  _autenticacaoRepositorio.Login(usuario);

            if (!usuarioLogado)
            {
                return null;
            }

            Tuple<string, DateTime> token = JwtServico.GerarToken(usuario);
            return token;
        }
    }
}
