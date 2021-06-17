using Dev_API.Dominio.Entidade;
using Dev_API.Dominio.Interfaces.Repositório;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev_API.Repositorio.Repositorios
{
    public class LinguagemRepositorio : ILinguagemRepositorio
    {
        public bool Alterar(int idDaLnguagem, string nomeDaLinguagem)
        {
            throw new NotImplementedException();
        }

        public Linguagem Consultar(int idDaLnguagem)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
