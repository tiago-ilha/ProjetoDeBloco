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

        public AvaliacaoVM()
        {
            turma = new TurmaVM();
            Questoes = new List<QuestaoVM>();
        }



        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe a Data de Início!")]
        [Display(Name = "Data de Início")]
        [DataType(DataType.Date)]
        public DateTime dtInicio { get; set; }     

        [Required(ErrorMessage = "Informe a Data de Fim!")]
        [Display(Name = "Data Fim")]
        [DataType(DataType.Date)]
        public DateTime dtFim { get; set; }

        [Required(ErrorMessage = "Informe qual o objetivo dessa avaliação!")]
        [Display(Name = "Objetivo")]
        public String objAvaliacao { get; set; }

        public virtual TurmaVM turma { get; set; }

        [Required(ErrorMessage = "Informe a turma!")]
        [Display(Name = "Código da Turma")]
        public Guid IdTurma { get; set; }

        public IList<QuestaoVM> Questoes { get; set; }

        public string GetCodigoNome
        {
            get 
            {
                return this.turma.Identificador;
            }
        }
    }
}
