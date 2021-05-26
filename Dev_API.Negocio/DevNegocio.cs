using Dev_API.Dominio.Entidade;
using Dev_API.Dominio.Interfaces.Negocio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev_API.Negocio
{
    public class DevNegocio : IDevNegocio
    {
        public bool Alterar(int CodigoDoDev, string NomeDoDev)
        {
            throw new NotImplementedException();
        }

        public Dev Consultar(int codigoDoDev)
        {
            throw new NotImplementedException();
        }

        public bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public bool Incluir(Dev dev)
        {
            throw new NotImplementedException();
        }

        public List<Dev> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
