using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using ProjetoDeBloco.UI.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDeBloco.UI.Controllers
{
    [AutentificacaoFiltro]
	public class AvaliacaoController : BaseController
    { 

        public IAvaliacaoServico _servicoAvaliacao;
        public ITurmaServico _servicoTurma;
        public IQuestaoServico _servicoQuestao;


        public AvaliacaoController(IAvaliacaoServico servicoAvaliacao, ITurmaServico servicoTurma, IQuestaoServico servicoQuestao)
        {
            _servicoAvaliacao = servicoAvaliacao;

            _servicoTurma = servicoTurma;

            _servicoQuestao = servicoQuestao;
        }
        //
        // GET: /Avaliacao/
        public ActionResult Index()
        {

            //var listaAvaliacao = CarregaAvaliacao();



            IList<AvaliacaoVM> avaLList = new List<AvaliacaoVM>();

            foreach (var item in _servicoAvaliacao.ListarTodos())
            {
                AvaliacaoVM avaliacao = new AvaliacaoVM();


                avaliacao.dtFim = item.dtFim;
                avaliacao.dtInicio = item.dtInicio;
                avaliacao.objAvaliacao = item.objAvaliacao;
                avaliacao.Id = item.Id;
                avaliacao.turma = _servicoTurma.BuscarPorId(item.turma.Id);
                avaliacao.Questoes = item.Questoes;



                avaLList.Add(avaliacao);

            }

            return View(avaLList);

        }


        public ActionResult Cadastrar()
        {
            carrregaTurma();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(AvaliacaoVM model)
        {
            CarregarDadosDaTurma(model);

            MontarDadosDasQuestoes(model);

            _servicoAvaliacao.Cadastrar(model);

            ModelState.Clear();

            return RedirectToAction("Index");

            CarregarTurma();
        }

        private void MontarDadosDasQuestoes(AvaliacaoVM model)
        {
            IList<QuestaoVM> listaDeQuestoes = new List<QuestaoVM>();

            foreach (var item in model.Questoes)
            {
                var questoesBase = _servicoQuestao.BuscarPorPergunta(item.PerguntaQuestao);

                QuestaoVM questaoVm = new QuestaoVM
                {
                    Id = questoesBase.Id,
                    PerguntaQuestao = questoesBase.PerguntaQuestao,
                    Resposta1 = questoesBase.Resposta1,
                    Resposta2 = questoesBase.Resposta2,
                    Resposta3 = questoesBase.Resposta3,
                    Resposta4 = questoesBase.Resposta4,
                    Resposta5 = questoesBase.Resposta5
                };

                listaDeQuestoes.Add(questaoVm);
            }

            model.Questoes = null;
            model.Questoes = listaDeQuestoes;



        }

        private void CarregarTurma()
        {
            ViewBag.Turmas = new SelectList(_servicoTurma.ListarTodos(), "Id", "Identificador");
        }

        private void CarregarDadosDaTurma(AvaliacaoVM model)
        {            
            Guid idTurma;
            if (Request.Form["TurmaID"] != "")
            {
                idTurma = Guid.Parse(Request.Form["TurmaID"]);
                model.IdTurma = idTurma;
                model.turma = _servicoTurma.BuscarPorId(model.IdTurma);
            }
            else
            {
                idTurma = Guid.Empty;
                model.turma.Id = idTurma;
            }  
        }

        protected IList<AvaliacaoVM> CarregaAvaliacao()
        {
            IList<AvaliacaoVM> avaLList = new List<AvaliacaoVM>();

            foreach (var item in _servicoAvaliacao.ListarTodos())
            {
                AvaliacaoVM avaliacao = new AvaliacaoVM();


                avaliacao.dtFim = item.dtFim;
                avaliacao.dtInicio = item.dtInicio;
                avaliacao.objAvaliacao = item.objAvaliacao;
                avaliacao.Id = item.Id;

                avaliacao.turma = new TurmaVM();
                avaliacao.turma.Id = item.turma.Id;

                avaLList.Add(avaliacao);
                
            }

            return avaLList;
        }

        public void carrregaTurma()
        {
            ViewBag.TurmaID = new SelectList(_servicoTurma.ListarTodos(), "Id", "Identificador"); 
        }
    }
}