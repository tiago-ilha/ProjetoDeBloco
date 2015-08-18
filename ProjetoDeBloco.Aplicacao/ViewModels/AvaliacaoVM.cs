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
        [Display(Name = "Data de Início")]
        public DateTime dtInicio { get; set; }     

        [Required(ErrorMessage = "Informe a Data de Fim!")]
        [Display(Name = "Data Fim")]
        public DateTime dtFim { get; set; }

        [Display(Name = "Objetivo")]
        public String objAvaliacao { get; set; }

        public virtual TurmaVM turma { get; set; }

        [Display(Name = "Código da Turma")]
        public Guid IdTurma { get; set; }

        public string GetCodigoNome
        {
            get 
            {
                return this.turma.Identificador;
            }
        }
    }
}
