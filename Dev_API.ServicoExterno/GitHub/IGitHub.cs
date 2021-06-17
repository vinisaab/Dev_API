using Dev_API.Dominio.Entidade.GitHub;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dev_API.ServicoExterno.GitHub
{
    public interface IGitHub
    {
        Task<GithubApi.GitHub> ConsultarGitHub(string usuario);
    }
}
