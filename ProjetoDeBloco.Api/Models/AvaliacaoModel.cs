using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoDeBloco.Api.Models
{
    public class AvaliacaoModel
    {
        public Guid Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Objetivo { get; set; }
        public TurmaModel Turma { get; set; }
        
    }
}