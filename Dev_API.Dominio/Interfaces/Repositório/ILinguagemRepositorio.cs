using Dev_API.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev_API.Dominio.Interfaces.Repositório
{
    public interface ILinguagemRepositorio
    {
        Linguagem Consultar(int idDaLnguagem);
        List<Linguagem> Listar();
        bool Incluir(Linguagem linguagem);
        public bool Alterar(int idDaLnguagem, string nomeDaLinguagem);
        bool Excluir(int idDaLnguagem);
    }
}
