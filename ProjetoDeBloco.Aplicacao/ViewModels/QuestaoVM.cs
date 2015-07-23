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
        public string Descricao { get; set; }
        public IList<RespostaVM> Respostas { get; set; }
    }
}
