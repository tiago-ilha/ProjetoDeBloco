using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.Administracao
{
    public class Recurso
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public Guid IdPerfil { get; set; }
        public virtual Perfil Perfil { get; set; }
        public virtual ICollection<RecursoFilho> RecursoFilhos { get; set; }
    }
}
