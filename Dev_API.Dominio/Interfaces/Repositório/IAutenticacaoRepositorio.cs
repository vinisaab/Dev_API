using Dev_API.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev_API.Dominio.Interfaces.Repositório
{
    public interface IAutenticacaoRepositorio
    {
        bool Login(Usuario usuario);
    }
}
