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
        public TurmaVM()
        {
            Alunos = new List<AlunoVM>();
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe um identificador!")]
        public int Identificador { get; set; }

        [Display(Name="Módulo")]
        [Required(ErrorMessage="Informe um módulo!")]
        public Guid IdModulo { get; set; }
        public ModuloVM Modulo { get; set; }
        
        public IList<AlunoVM> Alunos { get; set; }
    }
}
