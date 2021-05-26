using System;
using System.Collections.Generic;
using System.Text;

namespace Dev_API.Dominio.Entidade
{
    public class Dev
    {

        public int IDDoDev { get; set; }
        public string NomeDoDev { get; set; }
        public string CpfDoDev { get; set; }
        public string EmailDoDev { get; set; }
        public string UsuarioGitHubDoDev { get; set; }
        public string LinkGitHubDoDev { get; set; }
        public int QuantidadeRepositoriosDoDev { get; set; }
        public bool DisponivelParaContratacao { get; set; }
           
    }
}
