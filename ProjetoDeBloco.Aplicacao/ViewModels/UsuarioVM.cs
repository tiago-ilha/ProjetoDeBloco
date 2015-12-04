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

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Informe o e-mail do coordenador!")]
		public string Email { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Informe o login do coordenador!")]
		public string Login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe o senha do coordenador!")]
		public string Senha { get; set; }

		public SituacaoUsuario Situacao { get; set; }
	}
}
