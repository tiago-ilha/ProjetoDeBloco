using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.ViewModels
{
    public class QuestaoVM
    {
        public Guid Id { get; set; }
        public String PerguntaQuestao { get; set; }
        public String Resposta1 { get; set; }
        public String Resposta2 { get; set; }
        public String Resposta3 { get; set; }
        public String Resposta4 { get; set; }
        public String Resposta5 { get; set; }

    }
}
