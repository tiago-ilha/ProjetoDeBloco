using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDeBloco.Api.Models
{
    public class ModuloModel
    {
        public string Nome { get; set; }
        public BlocoModel Bloco { get; set; }
    }
}