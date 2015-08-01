using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura
{
    public class Curso
    {
        protected Curso() { }

        public Curso(string codigo, string nome)
        {
            if (string.IsNullOrEmpty(nome)) throw new Exception("Informe o nome do curso!");
            if (nome.Length < 5) throw new Exception("Informe o nome do curso com no mínimo 5!");
            if (nome.Length > 80) throw new Exception("Informe o nome do curso com no máximo 80!");

            this.Id = Guid.NewGuid();
            this.Codigo = codigo;
            this.Nome = nome;
        }

        public Guid Id { get; set; }
        public string Codigo { get; private set; }
        public string Nome { get; private set; }       

        public void Editar(string codigo, string nome)
        {
            if (string.IsNullOrEmpty(nome)) throw new Exception("Informe o nome do curso!");
            if (nome.Length < 5) throw new Exception("Informe o nome do curso com no mínimo 5!");
            if (nome.Length > 80) throw new Exception("Informe o nome do curso com no máximo 80!");

            this.Nome = nome;
        }
    }
}
