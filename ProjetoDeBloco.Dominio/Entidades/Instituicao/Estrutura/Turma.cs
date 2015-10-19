<<<<<<< HEAD
﻿using System;
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

        public Turma(string identificador, Guid idModulo, Guid idProfessor)
        {
            if (string.IsNullOrEmpty(identificador)) throw new Exception("Informe o identificador da turma!");
            if (idModulo == Guid.Empty) throw new Exception("Informe um módulo!");
            if (idProfessor == Guid.Empty) throw new Exception("Informe um Professor!");

            this.Id = Guid.NewGuid();
            this.Identificador = identificador;
            this.IdModulo = idModulo;
            this.IdProfessor = idProfessor;
            
            this.Alunos = new HashSet<Aluno>();
        }
        public Guid Id { get; set; }
        public string Identificador { get; private set; }
        public Guid IdModulo { get; private set; }
        public Guid IdProfessor { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual Modulo Modulo { get; private set; }
        public virtual HashSet<Aluno> Alunos { get; private set; }



        public void AdicionarAluno(Aluno aluno)
        {
            Alunos.Add(aluno);
        }

        public void Editar(Guid idModulo,string identificador, Guid idProfessor)
        {
            if (identificador == null) throw new Exception("Informe o identificador da turma!");
            if(idModulo == Guid.Empty) throw new Exception("Informe um módulo!");            
            if (idProfessor == Guid.Empty) throw new Exception("Informe um Professor!");

            this.Identificador = identificador;
            this.IdModulo = idModulo;
            this.IdProfessor = idProfessor;            
        }
    }
}
=======
﻿using System;
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

        public Turma(string identificador, Guid idModulo, Guid idProfessor)
        {
            if (string.IsNullOrEmpty(identificador)) throw new Exception("Informe o identificador da turma!");
            if (idModulo == Guid.Empty) throw new Exception("Informe um módulo!");
            if (idProfessor == Guid.Empty) throw new Exception("Informe um Professor!");

            this.Id = Guid.NewGuid();
            this.Identificador = identificador;
            this.ModuloID = idModulo;
            this.ProfessorID = idProfessor;
            
            this.Alunos = new HashSet<Aluno>();
        }
        public Guid Id { get; set; }
        public string Identificador { get; private set; }
        public Guid ModuloID { get; private set; }
        public Guid ProfessorID { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual Modulo Modulo { get; private set; }
        public virtual ICollection<Aluno> Alunos { get; private set; }



        public void AdicionarAluno(Aluno aluno)
        {
            Alunos.Add(aluno);
        }

        public void LimparAlunos()
        {
            Alunos.Clear();
        }

        public void Editar(Guid idModulo,string identificador, Guid idProfessor)
        {
            if (identificador == null) throw new Exception("Informe o identificador da turma!");
            if(idModulo == Guid.Empty) throw new Exception("Informe um módulo!");            
            if (idProfessor == Guid.Empty) throw new Exception("Informe um Professor!");

            this.Identificador = identificador;
            this.ModuloID = idModulo;
            this.ProfessorID = idProfessor;            
        }
    }
}
>>>>>>> 783aa6575c0558e368e19a68b44aeb2233109a24
