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

        public Turma(Guid idModulo, int identificador)
        {
            if (idModulo == Guid.Empty) throw new Exception("Informe um módulo!");
            if (identificador == 0) throw new Exception("Informe o identificador da turma!");

            this.IdModulo = idModulo;
            this.Identificador = identificador;
            this.Alunos = new HashSet<Aluno>();
        }
        public Guid Id { get; set; }
        public int Identificador { get; private set; }
        public Guid IdModulo { get; private set; }
        public virtual Modulo Modulo { get; private set; }
        public virtual HashSet<Aluno> Alunos { get; private set; }

        public void AdicionarAluno(Aluno aluno)
        {
            Alunos.Add(aluno);
        }

        public void Editar(Guid idModulo,int identificador)
        {
            if(idModulo == Guid.Empty) throw new Exception("Informe um módulo!");
            if (identificador == null) throw new Exception("Informe o identificador da turma!");

            this.Identificador = identificador;
            this.IdModulo = idModulo;            
        }
    }
}
