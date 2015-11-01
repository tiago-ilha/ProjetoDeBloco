using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDeBloco.Api.Models
{
    public class TurmaModel
    {
        public string Identificador { get; set; }
        public ProfessorModel Professor { get; set; }
        public ModuloModel Modulo { get; set; }
    }
}