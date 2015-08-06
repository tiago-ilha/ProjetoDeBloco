using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.ViewModels
{
    public class AvaliacaoVM
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe a Data de Início!")]
        public DateTime dtInicio { get; set; }     
        [Required(ErrorMessage = "Informe a Data de Fim!")]
        public DateTime dtFim { get; set; }
         

        public String objAvaliacao { get; set; }

        public virtual TurmaVM turma { get; set; }
        public Guid IdTurma { get; set; }  
    }
}
