using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using ProjetoDeBloco.Dominio.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.Administracao
{
	public class Usuario
	{
		protected Usuario() { }

		public Usuario(string email, string login, string senha)
		{
			if (string.IsNullOrWhiteSpace(email)) throw new Exception("Informe o e-mail do usuário!");
			if (string.IsNullOrWhiteSpace(login)) throw new Exception("Informe o login do usuário!");
			if (string.IsNullOrWhiteSpace(senha)) throw new Exception("Informe a senha do usuário!");
		}

		public Guid Id { get; private set; }
		public string Email { get; private set; }
		public string Login { get; private set; }
		public string Senha { get; private set; }
		public SituacaoUsuario Situacao { get; private set; }

        public Guid IdAdmistrador { get; set; }
        public virtual Administrador Adminstrador { get; set; }

		public void TrocarEmail(string email)
		{
			if (string.IsNullOrWhiteSpace(Email)) throw new Exception("Informe o e-mail do usuário!");

			this.Email = email;
		}

		public void TrocarSenha(string senha)
		{
			if (string.IsNullOrWhiteSpace(Senha)) throw new Exception("Informe senha do usuário!");

			this.Senha = senha;
		}

		public void AtivarUsuario()
		{
			if (Situacao == SituacaoUsuario.Ativo)
				throw new Exception("Usuário já está ativado!");

			this.Situacao = SituacaoUsuario.Ativo;
		}

		public void DesativarUsuario()
		{
			if (Situacao == SituacaoUsuario.Inativo)
				throw new Exception("Usuário já está inativo!");

			this.Situacao = SituacaoUsuario.Inativo;
		}
	}
}
