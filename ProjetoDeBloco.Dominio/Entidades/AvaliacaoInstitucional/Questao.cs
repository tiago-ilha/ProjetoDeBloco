using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.AvaliacaoInstitucional
{
    public class Questao
    {

        public Questao (){}

        public Questao(string PerguntaQuestao, string Resposta1, string Resposta2, string Resposta3,  string Resposta4,  string Resposta5)
        {
            //if (string.IsNullOrEmpty(nome)) throw new Exception("Informe o nome do curso!");
            //if (nome.Length < 5) throw new Exception("Informe o nome do curso com no mínimo 5!");
            //if (nome.Length > 80) throw new Exception("Informe o nome do curso com no máximo 80!");

            this.Id = Guid.NewGuid();
            this.PerguntaQuestao = PerguntaQuestao;
            this.Resposta1 = Resposta1;
            this.Resposta2 = Resposta2;
            this.Resposta3 = Resposta3;
            this.Resposta4 = Resposta4;
            this.Resposta5 = Resposta5;
        }


        public Guid Id { get; set; }
        public String PerguntaQuestao { get; set; }
        public String Resposta1 { get; set; }
        public String Resposta2 { get; set; }
        public String Resposta3 { get; set; }
        public String Resposta4 { get; set; }
        public String Resposta5 { get; set; }
    }
}
