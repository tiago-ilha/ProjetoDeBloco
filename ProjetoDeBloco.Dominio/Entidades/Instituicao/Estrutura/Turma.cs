using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;

namespace ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura
{
    public class Turma
    {
        protected Turma() { }

        public Turma(Guid idModulo)
        {
            this.IdModulo = idModulo;
            this.Alunos = new HashSet<Aluno>();
        }
        public Guid Id { get; private set; }
        public Guid IdModulo { get; private set; }
        public virtual Modulo Modulo { get; private set; }
        public virtual HashSet<Aluno> Alunos { get; private set; }

        public void AdicionarAluno(Aluno aluno)
        {
            Alunos.Add(aluno);
        }

        public void Editar(Guid idModulo)
        {
            if(idModulo == Guid.Empty) throw new Exception("Informe um módulo!");

            this.IdModulo = idModulo;
        }
    }
}
