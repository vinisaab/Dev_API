using Dev_API.Dominio.Entidade.GitHub;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev_API.Dominio.Entidade.DTO
{
    public class Github
    {
        public Github()
        {

        }

        public Github(GithubApi.GitHub github)
        {
            this.LinkGitHubDoDev = github.html_url;
            this.QuantidadeRepositoriosDoDev = github.public_repos;
            this.DisponivelParaContratacao = github.hireable;

        }


        public string LinkGitHubDoDev { get; set; }
        public int QuantidadeRepositoriosDoDev { get; set; }
        public bool DisponivelParaContratacao { get; set; }
    }
}
