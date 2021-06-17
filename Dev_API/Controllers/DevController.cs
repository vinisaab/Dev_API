using Dev_API.Dominio.Interfaces.Negocio;
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
        public IActionResult Get()
        {
            return Ok(_devNegocio.Listar());
        }


        /// <summary>
        /// Busca desenvolvedor pelo ID
        /// </summary>
        /// <param Codigo="id"></param>
        /// <returns></returns>
        // GET api/<DevController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dev = _devNegocio.Consultar(id);

            if (dev?.IDDoDev <= 0 && dev is not null)
                return NotFound(new
                {
                    sucesso = false,
                    mensagem = "Desenvolvedor não cadastrado."
                });

                         
            var git = _gitHubNegocio.Consultar(dev.UsuarioGitHubDoDev);

            //dev.LinkGitHubDoDev = git.LinkGitHubDoDev;
            //dev.QuantidadeRepositoriosDoDev = git.QuantidadeRepositoriosDoDev;
            //dev.DisponivelParaContratacao = git.DisponivelParaContratacao;

            return Ok(dev);
        }

        // POST api/<DevController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DevController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DevController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
