using ProjetoDeBloco.Dominio.Entidades.Administracao;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using ProjetoDeBloco.Infraestrutura.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Infraestrutura.Repositorios
{
	public class UsuarioRepositorio : IUsuarioRepositorio
	{
		private ProjetoDeBlocoDataContext _contexto;

		public UsuarioRepositorio(ProjetoDeBlocoDataContext contexto)
		{
			_contexto = contexto;
		}

		public bool JaExiste(string email)
		{
			throw new NotImplementedException();
		}

		public bool Login(string email, string login, string senha)
		{
			bool logar;

			if (!string.IsNullOrWhiteSpace(email))
			{
				 logar = LoginPorEmail(email, senha);
			}
			else
			{
				logar = LoginPorLogin(login,senha);
			}

			return logar;
		}

		private bool LoginPorEmail(string email, string senha)
		{
			return _contexto.Usuario.Any(x => x.Email.ToLower().Trim().Equals(email.ToLower().Trim()) && x.Senha.ToLower().Trim().Equals(senha.ToLower().Trim()));
		}

		private bool LoginPorLogin(string login, string senha)
		{
			return _contexto.Usuario.Any(x => x.Email.ToLower().Trim().Equals(login.ToLower().Trim()) && x.Senha.ToLower().Trim().Equals(senha.ToLower().Trim()));
		}

		public IEnumerable<Usuario> ObterPor()
		{
			return _contexto.Usuario.ToList();
		}

		public Usuario ObterPor(Guid id)
		{
			return _contexto.Usuario.Where(x => x.Id == id).FirstOrDefault();
		}

		public void Salvar(Usuario entidade)
		{
			_contexto.Usuario.Add(entidade);
			_contexto.SaveChanges();
		}

		public void Atualizar(Usuario entidade)
		{
			_contexto.Entry<Usuario>(entidade).State = EntityState.Modified;
		}

		public void Remover(Usuario entidade)
		{
			_contexto.Usuario.Remove(entidade);
		}

		public void Dispose()
		{
			_contexto.Dispose();
		}
	}
}
