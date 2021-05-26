using Dev_API.Dominio.Entidade.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev_API.Dominio.Interfaces.Negocio
{
    public interface IGithubNegocio
    {
        Github Consultar(string usuarioDoGitHub);
    }
}
