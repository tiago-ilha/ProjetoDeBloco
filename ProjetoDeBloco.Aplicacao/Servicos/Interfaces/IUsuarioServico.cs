using ProjetoDeBloco.Aplicacao.ViewModels;
using ProjetoDeBloco.Dominio.Entidades.Administracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.Servicos.Interfaces
{
	public interface IUsuarioServico : IAplicacaoBase<UsuarioVM>
	{
        UsuarioVM Logar(string login, string senha);
		bool JaExiste(string email);
	}
}
