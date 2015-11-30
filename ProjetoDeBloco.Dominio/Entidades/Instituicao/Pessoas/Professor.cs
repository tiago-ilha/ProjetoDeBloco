﻿using ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas
{
    public class Professor : Pessoa
    {
        protected Professor() { }

        public Professor(string nome, string email, DateTime dataNascimento, string areaDeFormacao, int anoDeFormacao)
            : base(nome, email, dataNascimento)
        {
            if (string.IsNullOrEmpty(areaDeFormacao)) throw new Exception("Informe a área de formação!");
            if (areaDeFormacao.Length < 10) throw new Exception("Informe  a área de formação com no mínimo 10 caracteres!");
            if (anoDeFormacao == null) throw new Exception("Informe o ano de formação!");

            this.AreaDeFormacao = areaDeFormacao;
            this.AnoDeFormacao = anoDeFormacao;
        }
       
        public string AreaDeFormacao { get; set; }
        public int AnoDeFormacao { get; set; }

        public virtual ICollection<Turma> Turmas { get; set; }

        public void Editar(string nome, string email,DateTime dataNascimento, string areaDeFormacao, int anoDeFormacao)
        {
            if (string.IsNullOrEmpty(nome)) throw new Exception("Informe o nome!");
            if (nome.Length < 3) throw new Exception("Informe o nome com no mínimo 5!");
            if (nome.Length > 50) throw new Exception("Informe o nome com no máximo 50!");
            if (string.IsNullOrEmpty(email)) throw new Exception("Informe um e-mail!");
            if (dataNascimento == null) throw new Exception("Informe uma data de nascimento!");
            if (string.IsNullOrEmpty(AreaDeFormacao)) throw new Exception("Informe a área de formação!");
            if (areaDeFormacao.Length < 10) throw new Exception("Informe  a área de formação com no mínimo 10 caracteres!");
            if (anoDeFormacao == null) throw new Exception("Informe o ano de formação!");

            this.Nome = nome;
            this.Email = email;
            this.DataNascimento = dataNascimento;
            this.AreaDeFormacao = areaDeFormacao;
            this.AnoDeFormacao = anoDeFormacao;
        }
    }
}
