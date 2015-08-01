using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.ViewModels
{
    public class ModuloVM
    {
        public ModuloVM()
        {
            Bloco = new BlocoVM();
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do módulo!")]
        [MinLength(5, ErrorMessage = "Informe o nome do módulo com no mínimo 5 caracteres")]
        [MaxLength(80, ErrorMessage = "Informe o nome do módulo com no máximo 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Informe um bloco!")]
        [Display(Name="Bloco")]
        public Guid IdBloco { get; set; }
        public virtual BlocoVM Bloco { get; set; }
    }
}
