using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.ViewModels
{
    public class AdministradorVM
    {
        public AdministradorVM()
        {
            Usuario = new UsuarioVM();
        }

        public Guid Id { get;  set; }
        public long Matricula { get; set; }
        public string Nome { get;  set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get;  set; }
        public UsuarioVM Usuario { get; set; }
    }
}
