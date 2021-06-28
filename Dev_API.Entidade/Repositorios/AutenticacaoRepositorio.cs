using Dev_API.Dominio.Entidade;
using Dev_API.Dominio.Interfaces.Repositório;
using System;

namespace Dev_API.Repositorio.Repositorios
{
    public class AutenticacaoRepositorio : IAutenticacaoRepositorio
    {
        public bool Login(Usuario usuario)
        {
            if (usuario.LoginDoUsuario == "demo"
                && usuario.SenhaDoUsuario == "demo")
            {
                return true;
            }
            return false;
        }
    }
}
