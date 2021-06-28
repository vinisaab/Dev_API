using Dev_API.Dominio.Entidade;
using Dev_API.Dominio.Interfaces.Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dev_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class DevLinguagemController : ControllerBase
    {
        private readonly IDevLinguagemNegocio _devLinguagemNegocio;
        /// <summary>
        /// Construtor do Dev
        /// </summary>
        /// <param name="linguagemNegocio"></param>
        public DevLinguagemController(IDevLinguagemNegocio devLinguagemNegocio)
        {
            _devLinguagemNegocio = devLinguagemNegocio;
        }

        /// <summary>
        /// Lista todas as combinações de dev e linguagem
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(_devLinguagemNegocio.Listar());
        }

        /// <summary>
        /// Filtra resultados por Linguagem ou Desenvolvedor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id, string filtro)
        {

            if (filtro is null)
                return NotFound(new { sucesso = false, mensagem = "Preencha o filtro com 'Desenvolvedor' ou 'Linguagem'"});

            if (filtro.ToUpper().Trim() == "DESENVOLVEDOR")
            {
                var dev = _devLinguagemNegocio.Consultar(id);

                if (!dev.Any())
                    return NotFound(new
                    {
                        sucesso = false,
                        mensagem = " Não há linguagens cadastradas para este Desenvolvedor."
                    });

                return Ok(dev);
            }

            if (filtro.ToUpper().Trim() == "LINGUAGEM")
            {
                var lang = _devLinguagemNegocio.ConsultarLinguagem(id);

                if (!lang.Any())
                    return NotFound(new
                    {
                        sucesso = false,
                        mensagem = "Não há desenvolvedores cadastrados para esta Linguagem."
                    });

                return Ok(lang);
            }

            return NotFound(new
            {
                sucesso = false,
                mensagem = "Não há registros que correspondem a busca. ou o Filtro é inválido",
                filtro = "Preencha o filtro com 'Desenvolvedor' ou 'Linguagem'"
            });
        }

        
        // POST api/<LinguagemController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] DevLinguagem devlang)
        {

            bool devLinguagemCadastrada = _devLinguagemNegocio.Incluir(devlang);
            if (devLinguagemCadastrada)
                return Ok(new
                {
                    sucesso = devLinguagemCadastrada,
                    linguagem = devlang
                });

            return NotFound(devLinguagemCadastrada);
        }

        
        // DELETE api/<LinguagemController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            bool devLangExcluida = _devLinguagemNegocio.Excluir(id);

            if (devLangExcluida)
                return Ok(devLangExcluida);

            return NotFound(new
            {
                sucesso = false,
                mensagem = "Vínculo Linguagem x Desenvolvedor não encontrado."
            });
        }
    }
}
