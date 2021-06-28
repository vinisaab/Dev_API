using System;
using System.Collections.Generic;
using System.Text;

namespace Dev_API.Dominio.Entidade
{
    public class Usuario
    {
        public int CodigoUsuario { get; set; }
        public string LoginDoUsuario { get; set; }
        public string SenhaDoUsuario { get; set; }
        public string EmailDoUsuario { get; set; }

    }
}
