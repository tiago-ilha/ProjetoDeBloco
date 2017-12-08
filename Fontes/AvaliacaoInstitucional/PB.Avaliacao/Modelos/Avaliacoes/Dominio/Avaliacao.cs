using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PB.Avaliacao.Modelos.Avaliacoes.Dominio.Enums;
using PB.Avaliacao.Modelos.Avaliacoes.Dominio.ObjetosDeValor;

namespace PB.Avaliacoes.Modelos.Avaliacoes.Dominio
{
    public class Avaliacao
    {
        #region Construtores

        public Avaliacao()
        {
            Id = Guid.NewGuid();
            DataDeCadastro = DateTime.Now;
            DefinirStatus(TipoSituacaoAvaliacaoEnum.Cadastrada);

            _questoes = new List<Questao>();
        }

        public Avaliacao(Aluno aluno, Curso curso) : this()
        {
            Aluno = aluno;
            Curso = curso;
        }

         #endregion

        #region Propriedades

        public Guid Id { get; private set; }

        public Aluno Aluno { get; private set; }
        public Curso Curso { get; private set; }

        public DateTime DataDeCadastro { get; private set; }
        public DateTime? DataDeEnvio { get; private set; }
        public DateTime? DataDeRealizacao { get; private set; }

        public TipoSituacaoAvaliacaoEnum Status { get; private set; }
        
        private List<Questao> _questoes;
        public ICollection<Questao> Questoes
        {
            get { return _questoes; }
        }

        #endregion

        #region Métodos

        public void AdicionarQuestoes(List<Questao> listaDeQuestoes)
        {
            if (!ExisteQuestoesInformadas(listaDeQuestoes))
                throw new Exception("Nenhuma questão foi informada.");

            listaDeQuestoes.ForEach(x => AdicionarQuestao(x));
        }

        public void StatusEnviado()
        {
            DataDeEnvio = DateTime.Now;
            DefinirStatus(TipoSituacaoAvaliacaoEnum.Enviada);
        }

        public void StatusRealizado()
        {
            DataDeRealizacao = DateTime.Now;
            DefinirStatus(TipoSituacaoAvaliacaoEnum.Respondida);
        }

        #region Métodos Compartilhados

        private void DefinirStatus(TipoSituacaoAvaliacaoEnum status)
        {
            Status = status;
        }        

        private bool ExisteQuestoesInformadas(List<Questao> listaDeQuestoes)
        {
            return listaDeQuestoes.Count > 0;
        }

        private void AdicionarQuestao(Questao questao)
        {
            if (JaExisteQuestao(questao))
                throw new Exception("Questão já existe associada a avaliação.");

            _questoes.Add(questao);
        }

        private bool JaExisteQuestao(Questao questao)
        {
            return _questoes.Any(x => x.Descricao == questao.Descricao);
        }

        #endregion

        #endregion
    }
}
