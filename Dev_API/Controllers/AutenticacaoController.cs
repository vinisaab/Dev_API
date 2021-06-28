using Dev_API.Dominio.Entidade;
using Dev_API.Dominio.Interfaces.Negocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Dev_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticacaoNegocio _autenticacaoNegocio;
        public AutenticacaoController(IAutenticacaoNegocio autenticacaoNegocio)
        {
            _autenticacaoNegocio = autenticacaoNegocio;
        }
        

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Autenticar([FromBody] Usuario usuario)
        {
            Tuple<string, DateTime> tokenGerado = _autenticacaoNegocio.Login(usuario);

            if (string.IsNullOrEmpty(tokenGerado?.Item1))
            {
                return StatusCode(403, new { 
                    Sucesso = false,
                    Mensgem = "Usuário ou senha Incorretos."
                });
            }

            return Ok(new
            {
                Sucesso = true,
                Mensagem = "Usuário autenticado com sucesso!",
                data = new
                {
                    Token = tokenGerado.Item1,
                    Expiracao = tokenGerado.Item2
                }
            });
        }
    }
}
