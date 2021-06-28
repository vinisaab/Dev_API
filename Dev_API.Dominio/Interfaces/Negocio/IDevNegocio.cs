using System;
using System.Collections.Generic;
using System.Text;
using Dev_API.Dominio.Entidade;

namespace Dev_API.Dominio.Interfaces.Negocio
{
    public interface IDevNegocio
    {
        Dev Consultar(int codigoDoDev);
        List<Dev> Listar();
        bool Incluir(Dev dev);
        public bool Alterar(Dev dev);
        bool Excluir(int id);
    }
}
