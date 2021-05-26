using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dev_API.Repositorio.Conexao
{
    public interface IConexaoSqlServer
    {
        IDbConnection AbrirConexao();
    }
}
