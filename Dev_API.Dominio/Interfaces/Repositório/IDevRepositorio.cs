using Dev_API.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev_API.Dominio.Interfaces.Repositório
{
    public interface IDevRepositorio
    {
        Dev Consultar(int codigoDoDev);
        List<Dev> Listar();
        bool Incluir(Dev dev);
        public bool Alterar(Dev dev);
        bool Excluir(int id);
    }
}
