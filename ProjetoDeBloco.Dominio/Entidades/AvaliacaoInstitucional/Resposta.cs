using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.AvaliacaoInstitucional
{
    public class Resposta
    {
        public Resposta(string descricao)
        {
            this.Descricao = descricao;
        }

        public Guid Id { get; set; }
        public string Descricao { get; set; }

        public virtual Questao Questao { get; set; }
    }
}
