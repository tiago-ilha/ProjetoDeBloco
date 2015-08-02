using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.ViewModels
{
    public class TurmaVM
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe um identificador!")]
        public int Identificador { get; set; }

        [Display(Name="Módulo")]
        [Required(ErrorMessage="Informe um módulo!")]
        public Guid IdModulo { get; set; }
        
        public IList<AlunoVM> Alunos { get; set; }
    }
}
