using Dev_API.Dominio.Entidade.DTO;
using Dev_API.Dominio.Entidade.GitHub;
using Dev_API.Dominio.Interfaces.Negocio;
using Dev_API.ServicoExterno.GitHub;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dev_API.Negocio
{
    public class GitHubNegocio : IGithubNegocio
    {

        private readonly IGitHub _gitHub;

        public GitHubNegocio()
        {

        }

        public GitHubNegocio(IGitHub gitHub)
        {
            _gitHub = gitHub;
        }
        public Github Consultar(string user)
        {
            var result = _gitHub.ConsultarGitHub(user).Result;

            return new Github(result);
        }
    }
}
