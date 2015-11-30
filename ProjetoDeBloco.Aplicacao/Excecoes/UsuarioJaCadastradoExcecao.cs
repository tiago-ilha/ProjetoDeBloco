using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.Excecoes
{
	public class UsuarioJaCadastradoExcecao : Exception
	{
		public override string Message
		{
			get
			{
				return "Usuário já foi cadastrado com esse e-mail!";
			}
		}
	}
}
