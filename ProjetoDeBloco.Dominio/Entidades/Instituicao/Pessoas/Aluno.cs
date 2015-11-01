using ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas
{
    public class Aluno : Pessoa
    {
        protected Aluno() { }

        public Aluno(string nome, string email, DateTime dataNascimento)
            : base(nome, email, dataNascimento)
        {
            Turmas = new HashSet<Turma>();
        }

        public Guid IdAluno { get; set; }

        public virtual ICollection<Turma> Turmas { get; set; }

        public void Editar(string nome, string email, DateTime dataNascimento)
        {
            if (string.IsNullOrEmpty(nome)) throw new Exception("Informe o nome!");
            if (nome.Length < 3) throw new Exception("Informe o nome com no mínimo 5!");
            if (nome.Length > 50) throw new Exception("Informe o nome com no máximo 50!");
            if (string.IsNullOrEmpty(email)) throw new Exception("Informe um e-mail!");
            if (dataNascimento == null) throw new Exception("Informe uma data de nascimento!");

            this.Nome = nome;
            this.DataNascimento = dataNascimento;
        }
    }
}
