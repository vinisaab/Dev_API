using Dev_API.Dominio.Entidade;
using Dev_API.Dominio.Interfaces.Negocio;
using Dev_API.Dominio.Interfaces.Repositório;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev_API.Negocio
{
    public class LinguagemNegocio : ILinguagemNegocio
    {


        private readonly ILinguagemRepositorio _linguagemRepositorio;
        public LinguagemNegocio(ILinguagemRepositorio linguagemRepositorio)
        {
            _linguagemRepositorio = linguagemRepositorio;
        }

        public bool Alterar(int idDaLnguagem, string nomeDaLinguagem)
        {
            if (idDaLnguagem > 0)
            {
                return _linguagemRepositorio.Alterar(idDaLnguagem, nomeDaLinguagem);
            }
            return false;
        }

        public Linguagem Consultar(int idDaLnguagem)
        {
            if (idDaLnguagem > 0)
            {
                return _linguagemRepositorio.Consultar(idDaLnguagem);
            }
            return null;
        }

        public bool Excluir(int idDaLnguagem)
        {
            if (idDaLnguagem > 0)
            {
                return _linguagemRepositorio.Excluir(idDaLnguagem);
            }
            return false;
        }

        public bool Incluir(string nomeDaLinguagem)
        {
            return _linguagemRepositorio.Incluir(nomeDaLinguagem);
        }

        public List<Linguagem> Listar()
        {
            return _linguagemRepositorio.Listar();
        }
    }
}
