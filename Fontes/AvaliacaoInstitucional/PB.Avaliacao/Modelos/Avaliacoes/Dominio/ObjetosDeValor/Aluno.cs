using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Avaliacao.Modelos.Avaliacoes.Dominio.ObjetosDeValor
{
    public class Aluno
    {
        public Aluno(string nomeCompleto, Email email)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
        }

        public string NomeCompleto { get; private set; }
        public Email Email { get; private set; }
    }
}
