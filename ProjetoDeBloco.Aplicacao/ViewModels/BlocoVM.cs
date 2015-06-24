using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.ViewModels
{
    public class BlocoVM
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage="Informe o nome do bloco!")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Informe um curso para esse bloco!")]
        [Display(Name="Nome do curso")]

        public Guid IdCurso { get; set; }
        public CursoVM Curso { get; set; }

        public string CursoCodigoENome
        {
            get
            {
                return this.Curso.CodigoENome;
            }
        }
    }
}
