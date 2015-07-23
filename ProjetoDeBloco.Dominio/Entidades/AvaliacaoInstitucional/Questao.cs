using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Entidades.AvaliacaoInstitucional
{
    public class Questao
    {
        public Questao(string descricao)
        {
            if (string.IsNullOrEmpty(descricao)) throw new Exception("Informe uma pergunta!");

            this.Descricao = descricao;
            this._respostas = new HashSet<Resposta>();
        }

        public Guid Id { get; private set; }
        public string Descricao { get; private set; }

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
