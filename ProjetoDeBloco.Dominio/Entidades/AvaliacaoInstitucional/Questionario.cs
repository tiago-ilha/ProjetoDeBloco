using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.AvaliacaoInstitucional
{
    public class Questionario
    {
        public Questionario(string pergunta)
        {
            if (string.IsNullOrEmpty(pergunta)) throw new Exception("Informe uma pergunta!");

            this.Pergunta = pergunta;
            this._respostas = new HashSet<Resposta>();
        }

        public Guid Id { get; private set; }
        public string Pergunta { get; private set; }

        private HashSet<Resposta> _respostas;

        public virtual ICollection<Resposta> Respostas
        {
            get { return _respostas; }
            private set { _respostas = new HashSet<Resposta>(value); }
        }

        public void AdicionarRespostas(Resposta resposta)
        {
            _respostas.Add(resposta);
        }
    }
}
