using AutoMapper;
using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using ProjetoDeBloco.Dominio.Entidades.AvaliacaoInstitucional;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.Servicos
{
    public class QuestaoServico : IQuestaoServico
    {

        private IQuestaoRepositorio _repQuestao;

        public QuestaoServico(IQuestaoRepositorio repQuestao)
        {
            _repQuestao = repQuestao;
        }

        public IEnumerable<ViewModels.QuestaoVM> ListarTodos()
        {
            var questoes = _repQuestao.ObterPor();

            return Mapper.Map<IEnumerable<Questao>, IEnumerable<QuestaoVM>>(questoes);
        }

        public ViewModels.QuestaoVM BuscarPorId(Guid id)
        {
            var questao = _repQuestao.ObterPor(id);

            return Mapper.Map<Questao, QuestaoVM>(questao);
        }

        public void Cadastrar(ViewModels.QuestaoVM entidade)
        {
            Questao questao;

            if (entidade.Id == Guid.Empty)
            {
                questao = new Questao(entidade.PerguntaQuestao, entidade.Resposta1, entidade.Resposta2, entidade.Resposta3, entidade.Resposta4, entidade.Resposta5);

                var jaExisteCurso = _repQuestao.JaExiste(entidade.PerguntaQuestao);

                if (jaExisteCurso)
                    throw new Exception("Essa pergunta já existe");

                _repQuestao.Salvar(questao);
            }
            else
            {
                questao = _repQuestao.ObterPor(entidade.Id);

               // questao.Editar(entidade.PerguntaQuestao);

                _repQuestao.Atualizar(questao);
            }
        }

        public void Remover(ViewModels.QuestaoVM entidade)
        {
            var questao = _repQuestao.ObterPor(entidade.Id);

            _repQuestao.Remover(questao);
        }

        public void Dispose()
        {
            _repQuestao.Dispose();
        }
    }
}
