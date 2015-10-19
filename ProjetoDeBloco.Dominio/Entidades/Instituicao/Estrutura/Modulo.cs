using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura
{
    public class Modulo
    {
        protected Modulo() { }

        public Modulo(string nome, Guid idBloco)
        {
            if (string.IsNullOrEmpty(nome)) throw new Exception("Informe o nome do módulo!");
            if (nome.Length < 5) if (nome.Length < 3) throw new Exception("Informe o nome com no mínimo 5!");
            if (nome.Length > 50) throw new Exception("Informe o nome com no máximo 50!");
            if (idBloco == Guid.Empty) throw new Exception("Informe um bloco para o módulo!");

            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.IdBloco = idBloco;
            this.Turmas = new HashSet<Turma>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid IdBloco { get; set; }
        public virtual Bloco Bloco { get; set; }
        public virtual ICollection<Turma> Turmas { get; private set; }

        public void Editar(string nome, Guid idBloco)
        {
            if (string.IsNullOrEmpty(nome)) throw new Exception("Informe o nome do módulo!");
            if (nome.Length < 5) if (nome.Length < 3) throw new Exception("Informe o nome com no mínimo 5!");
            if (nome.Length > 50) throw new Exception("Informe o nome com no máximo 50!");
            if (idBloco == Guid.Empty) throw new Exception("Informe um bloco para o módulo!");

            this.Nome = nome;
            this.IdBloco = idBloco;
        }
    }
}
