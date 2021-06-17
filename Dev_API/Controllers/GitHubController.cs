using Dev_API.Dominio.Interfaces.Negocio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dev_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {

        private readonly IGithubNegocio _gitHubNegocio;
        /// <summary>
        /// Construtor do GitHub
        /// </summary>
        /// <param name="gitHubNegocio"></param>
        public GitHubController(IGithubNegocio gitHubNegocio)
        {
            _gitHubNegocio = gitHubNegocio;
        }

        // GET api/<GitHubController>/5

        /// <summary>
        /// Busca dodos do GitHub
        /// </summary>
        /// <param name="Usuário do GitHub"></param>
        /// <returns></returns>
        [HttpGet("{user}")]
        public IActionResult Get(string user)
        {
            var gitHubUser = _gitHubNegocio.Consultar(user);
            if (gitHubUser?.LinkGitHubDoDev == null)
            {
                return NotFound(new
                {
                    sucesso = false,
                    mensagem = "GitHub não encontrado."
                });
            }
            return Ok(gitHubUser);
        }
    }
}
