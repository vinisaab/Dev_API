using Dev_API.Dominio.Entidade;
using Dev_API.Dominio.Interfaces.Negocio;
using Dev_API.Dominio.Interfaces.Repositório;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev_API.Negocio
{
    public class DevNegocio : IDevNegocio
    {

        private readonly IDevRepositorio _devRepositorio;
        public DevNegocio(IDevRepositorio devRepositorio)
        {
            _devRepositorio = devRepositorio;
        }

        public bool Alterar(Dev dev)
        {
            if (dev.IDDoDev > 0)
            {
                return _devRepositorio.Alterar(dev);
            }
            return false;
        }

        public Dev Consultar(int codigoDoDev)
        {
            if (codigoDoDev > 0)
            {
                return _devRepositorio.Consultar(codigoDoDev);
            }
            return null;
        }

        public bool Excluir(int codigoDoDev)
        {
            if (codigoDoDev > 0)
            {
                return _devRepositorio.Excluir(codigoDoDev);
            }
            return false;
        }

        public bool Incluir(Dev dev)
        {
            return _devRepositorio.Incluir(dev);
        }

        public List<Dev> Listar()
        {
            return _devRepositorio.Listar();
        }
    }
}
