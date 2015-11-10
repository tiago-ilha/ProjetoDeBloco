using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDeBloco.Dominio.Enum;

namespace ProjetoDeBloco.Aplicacao.ViewModels
{
	public class UsuarioVM
	{
		public Guid Id { get; set; }
		public string Email { get; set; }
		public string Login { get; set; }
		public string Senha { get; set; }
		public SituacaoUsuario Situacao { get; set; }
	}
}
