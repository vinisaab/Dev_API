using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Dev_API.Repositorio.Conexao
{
    public class ConexaoSqlServer : IConexaoSqlServer
    {
        private IDbConnection _db;
        private string _connectionString;


        public ConexaoSqlServer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("basicsAPI");
        }

        public IDbConnection AbrirConexao()
        {
            _db = new SqlConnection(_connectionString);
            try
            {
                _db.Open();
            }
            catch (Exception ex)
            {
                //TODO
                throw;
            }
            return _db;
        }
    }
}
