using ProjetoDeBloco.Dominio.Entidades.Administracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Interfaces.Repositorios
{
	public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
	{
		bool JaExiste(string email);
		bool Login(string login, string senha);
        Usuario ObterUsuarioPorLogin(string login);
	}
}
