using Dev_API.Dominio.Entidade;
using Dev_API.Dominio.Interfaces.Negocio;
using Dev_API.Dominio.Interfaces.Repositório;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev_API.Negocio
{
    public class DevLinguagemNegocio : IDevLinguagemNegocio
    {

        private readonly IDevLinguagemRepositorio _langDevRepositorio;
        public DevLinguagemNegocio(IDevLinguagemRepositorio langDevRepositorio)
        {
            _langDevRepositorio = langDevRepositorio;
        }

        public List<DevLinguagem> Consultar(int codigoDoDev)
        {
            if (codigoDoDev > 0)
            {
                return _langDevRepositorio.Consultar(codigoDoDev);
            }
            return null;
        }

        public List<DevLinguagem> ConsultarLinguagem(int codigoDaLinguagem)
        {
            if (codigoDaLinguagem > 0)
            {
                return _langDevRepositorio.ConsultarLinguagem(codigoDaLinguagem);
            }
            return null;
        }

        public bool Excluir(int id)
        {
            if (id > 0)
            {
                return _langDevRepositorio.Excluir(id);
            }
            return false;
        }

        public bool Incluir(DevLinguagem devlang)
        {
            return _langDevRepositorio.Incluir(devlang);
        }

        public List<DevLinguagem> Listar()
        {
            return _langDevRepositorio.Listar();
        }
    }
}
