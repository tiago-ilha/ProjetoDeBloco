using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas
{
    public class Aluno : Pessoa
    {
        protected Aluno(){}

        public Aluno(string nome, DateTime dataNascimento)
            : base(nome, dataNascimento)
        {

        }

        public Guid IdAluno { get; set; }

        public void Editar(string nome, DateTime dataNascimento)
        {
            if (string.IsNullOrEmpty(nome)) throw new Exception("Informe o nome!");
            if (nome.Length < 3) throw new Exception("Informe o nome com no mínimo 5!");
            if (nome.Length > 50) throw new Exception("Informe o nome com no máximo 50!");
            if (dataNascimento == null) throw new Exception("Informe uma data de nascimento!");

            this.Nome = nome;
            this.DataNascimento = dataNascimento;
        }
    }
}
