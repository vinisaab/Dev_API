using Dev_API.Dominio.Entidade;
using Dev_API.Dominio.Interfaces.Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Dev_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevController : ControllerBase
    {

        private readonly IDevNegocio _devNegocio;
        private readonly IGithubNegocio _gitHubNegocio;
        /// <summary>
        /// Construtor do Dev
        /// </summary>
        /// <param name="devNegocio"></param>
        public DevController(IDevNegocio devNegocio, IGithubNegocio gitHubNegocio)
        {
            _devNegocio = devNegocio;
            _gitHubNegocio = gitHubNegocio;
        }


        /// <summary>
        /// Lista Todos os Desenvolvedores
        /// </summary>
        /// <returns>Desenvolvedor</returns> 
        // GET: api/<DevController>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(_devNegocio.Listar());
        }


        /// <summary>
        /// Busca desenvolvedor pelo ID
        /// </summary>
        /// <param Codigo="id"></param>
        /// <returns>Desenvolvedor</returns>
        // GET api/<DevController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var dev = _devNegocio.Consultar(id);

            if (dev?.IDDoDev <= 0 && dev is not null)
                return NotFound(new
                {
                    sucesso = false,
                    mensagem = "Desenvolvedor não cadastrado."
                });
                         
            return Ok(dev);
        }

        /// <summary>
        /// Cadastro de Dev
        /// </summary>
        /// <param name="dev"></param>
        /// <returns>Resultado da Inclusão</returns>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Dev dev)
        {

            var git = _gitHubNegocio.Consultar(dev.UsuarioGitHubDoDev);

            dev.LinkGitHubDoDev = git.LinkGitHubDoDev;
            dev.QuantidadeRepositoriosDoDev = git.QuantidadeRepositoriosDoDev;
            dev.DisponivelParaContratacao = git.DisponivelParaContratacao;

            bool devCadastrado = _devNegocio.Incluir(dev);
            if (devCadastrado)
                return Ok(new
                {
                    sucesso = devCadastrado,
                    desenvolvedor = dev
                });

            return NotFound(devCadastrado);
        }

        /// <summary>
        /// Alteração do Cliente, ao altera o usuário do gitHub, será feita uma nova consulta a API do GitHub
        /// </summary>
        /// <param name="dev"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put([FromBody] Dev dev)
        {
            
            var git = _gitHubNegocio.Consultar(dev.UsuarioGitHubDoDev);

            dev.LinkGitHubDoDev = git.LinkGitHubDoDev;
            dev.QuantidadeRepositoriosDoDev = git.QuantidadeRepositoriosDoDev;
            dev.DisponivelParaContratacao = git.DisponivelParaContratacao;

            bool devAlterado = _devNegocio.Alterar(dev);
            if (devAlterado)
                return Ok(devAlterado);

            return NotFound(new
            {
                sucesso = false,
                mensagem = "Desenvolvedor não encontrado."
            });
        }

        /// <summary>
        /// Exclui Desenvolvedor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            bool devExcluido = _devNegocio.Excluir(id);

            if (devExcluido)
                return Ok(devExcluido);

            return NotFound(new
            {
                sucesso = false,
                mensagem = "Desenvolvedor não encontrado."
            });
        }
    }
}
