using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB.Avaliacoes.Modelos.Avaliacoes.Dominio
{
    public class Questao
    {
        public Questao(string descricao)
        {
            this.Descricao = descricao;
        }

        public string Descricao { get; private set; }
    }
}
