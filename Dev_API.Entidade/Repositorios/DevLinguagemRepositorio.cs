using Dev_API.Dominio.Entidade;
using Dev_API.Dominio.Interfaces.Repositório;
using Dev_API.Repositorio.Conexao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev_API.Repositorio.Repositorios
{
    public class DevLinguagemRepositorio : IDevLinguagemRepositorio
    {
        private readonly IConexaoSqlServer _conexaoSql;
        public DevLinguagemRepositorio(IConexaoSqlServer conexaoSqlServer)
        {
            _conexaoSql = conexaoSqlServer;
        }

        public List<DevLinguagem> Consultar(int codigoDoDev)
        {
            string sql = @"
                SELECT [id]         as IDDoRelacionamento
                      ,[id_dev]     as IDDoDev
                      ,[id_lang]    as IDDaLinguagem
                FROM [dev_linguagem]
                where [id_dev] = @codigoDoDev
            ";

            return Dapper.SqlMapper.Query<DevLinguagem>(_conexaoSql.AbrirConexao(), sql, new { codigoDoDev }).ToList();
        }

        public List<DevLinguagem> ConsultarLinguagem(int codigoDaLinguagem)
        {
            string sql = @"
                SELECT [id]         as IDDoRelacionamento
                      ,[id_dev]     as IDDoDev
                      ,[id_lang]    as IDDaLinguagem
                FROM [dev_linguagem] 
                where [id_lang] = @codigoDaLinguagem
            ";

            return Dapper.SqlMapper.Query<DevLinguagem>(_conexaoSql.AbrirConexao(), sql, new { codigoDaLinguagem }).ToList();
        }

        public bool Excluir(int id)
        {
            string sql = @"
                delete from [dev_linguagem] 
                    where id = @id
            ";

            return Dapper.SqlMapper.Execute(_conexaoSql.AbrirConexao(), sql, new { id }) > 0;
        }

        public bool Incluir(DevLinguagem devlang)
        {
            string sql = @"
                insert into [dev_linguagem] 
                    ([id_dev],[id_lang]) 
                          values(@IDDoDev, @IDDaLinguagem)
            ";

            return Dapper.SqlMapper.Execute(_conexaoSql.AbrirConexao(), sql, devlang) > 0;
        }

        public List<DevLinguagem> Listar()
        {
            string sql = @"
                select 
                    [id]      as IDDoRelacionamento,
                    [id_dev]  as IDDoDev,
                    [id_lang] as IDDaLinguagem 
                from [dev_linguagem] 
               
            ";

            return Dapper.SqlMapper.Query<DevLinguagem>(_conexaoSql.AbrirConexao(), sql).ToList();
        }
    }
}
