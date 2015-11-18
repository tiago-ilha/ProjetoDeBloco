using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.Administracao
{
    public class Autorizacao
    {
        protected Autorizacao() { }

        public Autorizacao(Guid idUsuario, Guid idPerfil)
        {
            if (idUsuario == Guid.Empty) throw new Exception("Informe pelo menos um usuário!");
            if (idPerfil == Guid.Empty) throw new Exception("Informe um perfil!");

            this.IdUsuario = idUsuario;
            this.IdPerfil = idPerfil;
        }

        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdPerfil { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}
