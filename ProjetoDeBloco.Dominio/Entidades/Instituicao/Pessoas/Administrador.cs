using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas
{
    public class Administrador : Pessoa
    {
        protected Administrador() { }

        public Administrador(string nome, string email, DateTime dataNascimento)
            : base(nome, email, dataNascimento)
        {

        }

        public Guid IdAdministrador { get; set; }
		public Guid IdUsuario { get; set; }

    }
}
