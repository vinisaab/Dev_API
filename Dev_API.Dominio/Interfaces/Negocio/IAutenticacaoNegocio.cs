using Dev_API.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev_API.Dominio.Interfaces.Negocio
{
    public interface IAutenticacaoNegocio
    {
        Tuple<string, DateTime> Login(Usuario usuario);
    }
}
