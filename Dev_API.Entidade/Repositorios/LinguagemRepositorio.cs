using Dev_API.Dominio.Entidade;
using Dev_API.Dominio.Interfaces.Repositório;
using Dev_API.Repositorio.Conexao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev_API.Repositorio.Repositorios
{
    public class LinguagemRepositorio : ILinguagemRepositorio
    {
        private readonly IConexaoSqlServer _conexaoSql;
        public LinguagemRepositorio(IConexaoSqlServer conexaoSqlServer)
        {
            _conexaoSql = conexaoSqlServer;
        }


        public bool Alterar(int idDaLnguagem, string nomeDaLinguagem)
        {
            string sql = @"
                update [linguagem] 
                    set [nome] = @nomeDaLinguagem
                where id = @idDaLnguagem
            ";

            return Dapper.SqlMapper.Execute(_conexaoSql.AbrirConexao(), sql, new { idDaLnguagem, nomeDaLinguagem }) > 0;
        }

        public Linguagem Consultar(int idDaLnguagem)
        {
            string sql = @"
                select 
                    [id] as IDDaLinguagem,
                    [nome] as NomeDaLinguagem 
                from [linguagem] 
                where id = @idDaLnguagem
            ";

            return Dapper.SqlMapper.QueryFirstOrDefault<Linguagem>(_conexaoSql.AbrirConexao(), sql, new { idDaLnguagem });
        }

        public bool Excluir(int idDaLnguagem)
        {
            string sql = @"
                delete from [linguagem] 
                    where id = @idDaLnguagem
            ";

            return Dapper.SqlMapper.Execute(_conexaoSql.AbrirConexao(), sql, new { idDaLnguagem }) > 0;
        }

        public bool Incluir(string nomeDaLinguagem)
        {
            string sql = @"
                insert into [linguagem] ([nome])
                    values (@nomeDaLinguagem)
            ";

            return Dapper.SqlMapper.Execute(_conexaoSql.AbrirConexao(), sql, new { nomeDaLinguagem }) > 0;
        }

        public List<Linguagem> Listar()
        {
            string sql = @"
                select 
                    [id] as IDDaLinguagem,
                    [nome] as NomeDaLinguagem 
                from [linguagem] 
               
            ";

            return Dapper.SqlMapper.Query<Linguagem>(_conexaoSql.AbrirConexao(), sql).ToList();
        }
    }
}
