using ProjetoDeBloco.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.Servicos.Interfaces
{
	public interface IUsuarioServico : IAplicacaoBase<UsuarioVM>
	{
		bool Logar(string email, string login, string senha);
		bool JaExiste(string email);
	}
}
