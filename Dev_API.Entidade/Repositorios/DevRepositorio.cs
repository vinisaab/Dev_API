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


        public bool Alterar(Dev dev)
        {
            string sql = @"
                update [desenvolvedor] 
                    set  
                           [nome] = @NomeDoDev
                          ,[cpf] = @CpfDoDev
                          ,[email] = @EmailDoDev
                          ,[usuario_github] = @UsuarioGitHubDoDev
                          ,[link_github] = @LinkGitHubDoDev
                          ,[qtd_repo] = @QuantidadeRepositoriosDoDev
                          ,[disponivel] = @DisponivelParaContratacao
                    where id = @IDDoDev
            ";

            return Dapper.SqlMapper.Execute(_conexaoSql.AbrirConexao(), sql, dev) > 0;
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

        public bool Excluir(int codigoDoDev)
        {
            string sql = @"
                delete
                from [desenvolvedor]
                where id = @codigoDoDev
            ";

            return Dapper.SqlMapper.Execute(_conexaoSql.AbrirConexao(), sql, new { codigoDoDev }) > 0;
        }

        public bool Incluir(Dev dev)
        {
            string sql = @"
                insert into [desenvolvedor] 
                    ([nome],[cpf],[email],[usuario_github],[link_github],[qtd_repo],[disponivel]) 
                          values(@NomeDoDev, @CpfDoDev, @EmailDoDev, @UsuarioGitHubDoDev, @LinkGitHubDoDev, @QuantidadeRepositoriosDoDev, @DisponivelParaContratacao)
            ";

            return Dapper.SqlMapper.Execute(_conexaoSql.AbrirConexao(), sql, dev) > 0;
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
