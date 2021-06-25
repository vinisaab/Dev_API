using Dev_API.Dominio.Entidade;
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
    public class LinguagemController : ControllerBase
    {


        private readonly ILinguagemNegocio _linguagemNegocio;
        /// <summary>
        /// Construtor do Dev
        /// </summary>
        /// <param name="linguagemNegocio"></param>
        public LinguagemController(ILinguagemNegocio linguagemNegocio)
        {
            _linguagemNegocio = linguagemNegocio;
        }

        // GET: api/<LinguagemController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_linguagemNegocio.Listar());
        }

        // GET api/<LinguagemController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var lang = _linguagemNegocio.Consultar(id);

            if (lang?.IDDaLinguagem <= 0 && lang is not null)
                return NotFound(new
                {
                    sucesso = false,
                    mensagem = "Linguagem não cadastrada."
                });

            return Ok(lang);
        }

        // POST api/<LinguagemController>
        [HttpPost]
        public IActionResult Post([FromBody] string nomeDaLinguagem)
        {

            bool linguagemCadastrada = _linguagemNegocio.Incluir(nomeDaLinguagem);
            if (linguagemCadastrada)
                return Ok(new
                {
                    sucesso = linguagemCadastrada,
                    linguagem = nomeDaLinguagem
                });

            return NotFound(linguagemCadastrada);
        }

        // PUT api/<LinguagemController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string nome)
        {

            bool linguagemAlterada = _linguagemNegocio.Alterar(id, nome);
            if (linguagemAlterada)
                return Ok(linguagemAlterada);

            return NotFound(new
            {
                sucesso = false,
                mensagem = "Linguagem não encontrada."
            });
        }

        // DELETE api/<LinguagemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool langExcluida = _linguagemNegocio.Excluir(id);

            if (langExcluida)
                return Ok(langExcluida);

            return NotFound(new
            {
                sucesso = false,
                mensagem = "Desenvolvedor não encontrado."
            });
        }
    }
}
