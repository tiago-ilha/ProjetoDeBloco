using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.ViewModels
{
    public class CursoVM
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o código do curso!")]
        public string Codigo { get; set; }

        [Required(ErrorMessage="Informe o nome do curso!")]
        [MinLength(5, ErrorMessage = "Informe o nome do curso com no mínimo 5 caracteres")]
        [MaxLength(80, ErrorMessage = "Informe o nome do curso com no máximo 80 caracteres")]
        public string Nome { get; set; }

        [Display(Name="Código / Nome")]
        public string CodigoENome
        {
            get
            {
                return this.Codigo + " - " + this.Nome;
            }
        }
    }
}
