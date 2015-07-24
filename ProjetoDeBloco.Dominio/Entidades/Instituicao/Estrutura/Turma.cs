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

        public Turma(Modulo modulo)
        {
            this.Modulo = modulo;
            this.Alunos = new HashSet<Aluno>();
        }
        public Guid Id { get; private set; }
        public Modulo Modulo { get; private set; }
        public virtual HashSet<Aluno> Alunos { get; private set; }

        public void AdicionarAluno(Aluno aluno)
        {
            Alunos.Add(aluno);
        }
    }
}
