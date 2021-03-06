﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDeBloco.Dominio.Enum;

namespace ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas
{
	public class Pessoa
	{
		protected Pessoa() { }

		public Pessoa(string nome, string email, DateTime dataNascimento)
		{
			if (string.IsNullOrEmpty(nome)) throw new Exception("Informe o nome!");
			if (nome.Length < 3) throw new Exception("Informe o nome com no mínimo 5!");
			if (nome.Length > 50) throw new Exception("Informe o nome com no máximo 50!");
			if (string.IsNullOrEmpty(email)) throw new Exception("Informe um e-mail!");
			if (dataNascimento == null) throw new Exception("Informe uma data de nascimento!");

			this.Nome = nome;
			this.Email = email;
			this.DataNascimento = dataNascimento;
		}

		public Guid Id { get; protected set; }
		public long Matricula { get; set; }
		public string Nome { get; protected set; }
		public string Email { get; set; }
		public DateTime DataNascimento { get; protected set; }
	}
}
