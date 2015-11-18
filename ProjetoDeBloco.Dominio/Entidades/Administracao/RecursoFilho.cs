using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.Administracao
{
    public class RecursoFilho
    {
        protected RecursoFilho() { }

        public RecursoFilho(string nome, Guid idRecursoPai)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new Exception("Informe o nome do recurso filho!");
            if (idRecursoPai == Guid.Empty) throw new Exception("Informe o recurso pai!");

            this.Nome = nome;
            this.IdRecursoPai = idRecursoPai;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }

        public Guid IdRecursoPai { get; private set; }

        public virtual Recurso RecursoPai { get; set; }
    }
}
