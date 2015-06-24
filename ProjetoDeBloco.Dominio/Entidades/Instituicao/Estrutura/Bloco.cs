using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura
{
    public class Bloco
    {
        protected Bloco() { }       

        public Bloco(string nome, Guid IdCurso)
        {
            if (string.IsNullOrEmpty(nome)) throw new Exception("Informe um nome para o bloco!");
            if (nome.Length < 5) throw new Exception("Informe o nome do bloco com no mínimo 5!");
            if (nome.Length > 80) throw new Exception("Informe o nome do bloco com no máximo 80!");
            if (IdCurso == Guid.Empty) throw new Exception("Informe um curso para esse bloco!");

            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.IdCurso = IdCurso;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid IdCurso { get; set; }
        public virtual Curso Curso { get; set; }

        public void Editar(string nome, Guid IdCurso)
        {
            if (string.IsNullOrEmpty(nome)) throw new Exception("Informe um nome para o bloco!");
            if (nome.Length < 5) throw new Exception("Informe o nome do bloco com no mínimo 5!");
            if (nome.Length > 50) throw new Exception("Informe o nome do bloco com no máximo 50!");
            if (IdCurso == Guid.Empty) throw new Exception("Informe um curso para esse bloco!");

            this.Nome = nome;
            this.IdCurso = IdCurso;
        }
    }
}
