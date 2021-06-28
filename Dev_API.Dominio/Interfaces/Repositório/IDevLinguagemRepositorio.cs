using Dev_API.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev_API.Dominio.Interfaces.Repositório
{
    public interface IDevLinguagemRepositorio
    {
        List<DevLinguagem> Consultar(int codigoDoDev);

        List<DevLinguagem> ConsultarLinguagem(int codigoDaLinguagem);
        List<DevLinguagem> Listar();
        bool Incluir(DevLinguagem devlang);
        bool Excluir(int id);
    }
}
