using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.Administracao
{
    public class Perfil
    {
        protected Perfil() { }

        public Perfil(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new Exception("Informe o nome do perfil!");

            this.Nome = nome;
            this.Recursos = new List<Recurso>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Recurso> Recursos { get; private set; }

        public void AdicionaRecursos(IList<Recurso> recursos)
        {
            foreach (var item in recursos)
            {
                Recursos.Add(item);
            }
        }
    }
}
