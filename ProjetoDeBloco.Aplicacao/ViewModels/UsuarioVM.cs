using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDeBloco.Dominio.Enum;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDeBloco.Aplicacao.ViewModels
{
	public class UsuarioVM
	{
		public Guid Id { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string Login { get; set; }

		[Required]
		public string Senha { get; set; }

		public SituacaoUsuario Situacao { get; set; }
	}
}
