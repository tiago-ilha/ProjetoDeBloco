using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.ViewModels
{
    public class ProfessorVM
    {
        public Guid Id { get; set; }
        public long? Matricula { get; set; }

        [Required(ErrorMessage = "Informe o nome do Professor!")]
        [MinLength(5, ErrorMessage = "Informe o nome do Professor com no mínimo 5 caracteres")]
        [MaxLength(80, ErrorMessage = "Informe o nome do Professor com no máximo 80 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Informe a data de nascimento!")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Informe o nome do módulo!")]
        [MinLength(5, ErrorMessage = "Informe o nome da área de formação com no mínimo 5 caracteres")]
        [MaxLength(80, ErrorMessage = "Informe o nome da área de formação com no máximo 80 caracteres")]
        public string AreaDeFormacao { get; set; }

        public int AnoDeFormacao { get; set; }
        public bool Ativo { get; set; }
    }
}
