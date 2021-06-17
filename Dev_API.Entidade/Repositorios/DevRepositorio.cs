using Dev_API.Dominio.Entidade;
using Dev_API.Dominio.Interfaces.Repositório;
using Dev_API.Repositorio.Conexao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev_API.Repositorio.Repositorios
{
    public class DevRepositorio : IDevRepositorio
    {

        private readonly IConexaoSqlServer _conexaoSql;
        public DevRepositorio(IConexaoSqlServer conexaoSqlServer)
        {
            _conexaoSql = conexaoSqlServer;
        }


        public bool Alterar(int CodigoDoDev, string NomeDoDev)
        {
            throw new NotImplementedException();
        }

        public Dev Consultar(int codigoDoDev)
        {
            string sql = @"
                select     [id] as IDDoDev
                          ,[nome] as NomeDoDev
                          ,[cpf] as CpfDoDev
                          ,[email] as EmailDoDev
                          ,[usuario_github] as UsuarioGitHubDoDev
                          ,[link_github] as LinkGitHubDoDev
                          ,[qtd_repo] as QuantidadeRepositoriosDoDev
                          ,[disponivel] as DisponivelParaContratacao

                from [desenvolvedor]
                where id = @codigoDoDev
            ";

            return Dapper.SqlMapper.QueryFirstOrDefault<Dev>(_conexaoSql.AbrirConexao(), sql, new { codigoDoDev });
        }

        public bool Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public bool Incluir(Dev dev)
        {
            throw new NotImplementedException();
        }

        public List<Dev> Listar()
        {
            string sql = @"
                select     [id] as IDDoDev
                          ,[nome] as NomeDoDev
                          ,[cpf] as CpfDoDev
                          ,[email] as EmailDoDev
                          ,[usuario_github] as UsuarioGitHubDoDev
                          ,[link_github] as LinkGitHubDoDev
                          ,[qtd_repo] as QuantidadeRepositoriosDoDev
                          ,[disponivel] as DisponivelParaContratacao

                from [desenvolvedor]
                
            ";

            return Dapper.SqlMapper.Query<Dev>(_conexaoSql.AbrirConexao(), sql).ToList();
        }
    }
}
