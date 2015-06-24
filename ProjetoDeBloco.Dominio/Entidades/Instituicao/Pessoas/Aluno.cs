using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas
{
    public class Aluno : Pessoa
    {
        protected Aluno(){}

        public Aluno(string nome, DateTime dataNascimento)
            : base(nome, dataNascimento)
        {

        }

        public Guid IdAluno { get; set; }
    }
}
