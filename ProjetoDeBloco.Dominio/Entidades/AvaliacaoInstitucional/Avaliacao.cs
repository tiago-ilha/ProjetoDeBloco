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
        public Avaliacao() { }

        public Avaliacao(DateTime dtInicio, DateTime dtFim, string observacao)
            : this(dtInicio, dtFim, observacao, Guid.Empty)
        { }

        public Avaliacao(DateTime dtInicio, DateTime dtFim, string observacao, Guid idTurma)
        {
            if (dtInicio == DateTime.MinValue) throw new Exception("Informe uma data de início de avaliação válida!");
            if (dtFim == DateTime.MinValue) throw new Exception("Informe uma data final de avaliação válida!");
            if (string.IsNullOrEmpty(observacao)) throw new Exception("Informe a observação para a avaliação!");

            this.dtInicio = dtInicio;
            this.dtFim = dtFim;
            this.objAvaliacao = observacao;
            this.IdTurma = idTurma;

            this.Questoes = new HashSet<Questao>();
        }

        public Guid Id { get; set; }
        public DateTime dtInicio { get; set; }
        public DateTime dtFim { get; set; }
        public String objAvaliacao { get; set; }

        public virtual Turma turma { get; set; }
        public Guid IdTurma { get; set; }

        public virtual ICollection<Questao> Questoes { get; private set; }

        public void AdicionarQuestao(Questao questao)
        {
            Questoes.Add(questao);
        }

        public void Editar(DateTime dtInicio, DateTime dtFim, string observacao, Guid idTurma)
        {
            if (dtInicio == DateTime.MinValue) throw new Exception("Informe uma data de início de avaliação válida!");
            if (dtFim == DateTime.MinValue) throw new Exception("Informe uma data final de avaliação válida!");
            if (string.IsNullOrEmpty(observacao)) throw new Exception("Informe a observação para a avaliação!");

            this.dtInicio = dtInicio;
            this.dtFim = dtFim;
            this.objAvaliacao = observacao;
            this.IdTurma = idTurma;
        }

    }
}
