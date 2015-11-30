using ProjetoDeBloco.Dominio.Entidades.Administracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas
{
	public class Administrador : Pessoa
	{
		protected Administrador() { }

		public Administrador(string nome, string email, DateTime dataNascimento, Guid idUsuario)
			: base(nome, email, dataNascimento)
		{
			if (string.IsNullOrWhiteSpace(nome)) throw new Exception("Informe o nome do coordenador!");
			if (string.IsNullOrWhiteSpace(email)) throw new Exception("Informe o e-mail do coordenador!");
			if (dataNascimento == DateTime.MinValue) throw new Exception("Informe a data de nascimento do válida do coordenador!");
			if (idUsuario == Guid.Empty) throw new Exception("Não é possivel cadastrar um coordenador sem um usuário!");

			this.Nome = nome;
			this.Email = email;
			this.DataNascimento = dataNascimento;
			this.IdUsuario = idUsuario;
		}
		public Guid? IdUsuario { get; set; }

		public virtual Usuario Usuario { get; set; }

		public void TrocarNome(string nome)
		{
			if (string.IsNullOrWhiteSpace(nome)) throw new Exception("Informe o nome do administrador para trocar o nome do adminstrador!");

			this.Nome = nome;
		}

		public void TrocarEmail(string email)
		{
			if (string.IsNullOrWhiteSpace(email)) throw new Exception("Informe o e-mail do administrador para trocar o e-mail do adminstrador!");

			this.Email = email;
		}

		public void TrocarDataDeNascimento(DateTime dataNascimento)
		{
			if (dataNascimento == DateTime.MinValue) throw new Exception("Informe uma data de nascimento do administrador para trocar data de nascimento do adminstrador!");

			this.DataNascimento = dataNascimento;
		}
	}
}
