using ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.AvaliacaoInstitucional
{
    public class Avaliacao
    {

        public Avaliacao()
        {
          //  this.Questoes = new HashSet<Questao>();
        }
        
        
        public Guid Id { get; set; }   
        public DateTime dtInicio { get; set; }
        public DateTime dtFim { get; set; }
        public String objAvaliacao { get; set; }

        public virtual Turma turma { get; set; }
        public Guid IdTurma { get; set; }

       // public virtual HashSet<Questao> Questoes { get; private set; }




        public void AdicionarQuestao(Questao questao)
        {
           // Questoes.Add(questao);
        }

    }
}
