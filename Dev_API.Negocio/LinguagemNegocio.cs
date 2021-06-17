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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool Incluir(Linguagem linguagem)
        {
            throw new NotImplementedException();
        }

        public List<Linguagem> Listar()
        {
            return _linguagemRepositorio.Listar();
        }
    }
}
