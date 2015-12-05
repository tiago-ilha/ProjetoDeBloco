using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.ViewModels
{
	public class AdministradorVM
	{
		public AdministradorVM()
		{
			Usuario = new UsuarioVM();
		}

		public Guid Id { get; set; }
		public long Matricula { get; set; }

		[Required(ErrorMessage = "Informe o nome do coordenador!")]
		public string Nome { get; set; }
		public string Email { get; set; }

		[Display(Name = "Data Nascimento")]
		[DataType(DataType.Date)]
		[Required(ErrorMessage = "Informe a data de nascimento do coordenador!")]
		public DateTime DataNascimento { get; set; }

		public UsuarioVM Usuario { get; set; }
	}
}
