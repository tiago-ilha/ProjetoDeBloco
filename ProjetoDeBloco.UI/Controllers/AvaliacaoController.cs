using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using ProjetoDeBloco.UI.Filtros;
using ProjetoDeBloco.Utilitarios.ServicoEmail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
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
        public IAlunoServico _servicoAluno;


        public AvaliacaoController(IAvaliacaoServico servicoAvaliacao, ITurmaServico servicoTurma, IQuestaoServico servicoQuestao, IAlunoServico servicoAluno)
        {
            _servicoAvaliacao = servicoAvaliacao;
            _servicoTurma = servicoTurma;
            _servicoQuestao = servicoQuestao;
            _servicoAluno = servicoAluno;
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

        public ActionResult EnviarAvaliacao()
        {
            var avaliacaoAberta = _servicoAvaliacao.ListarTodos();

            var smtp = ConfigurationManager.AppSettings["smtpServer"];
            var porta = ConfigurationManager.AppSettings["Porta"];
            var email = ConfigurationManager.AppSettings["LoginEmail"];
            var senha = ConfigurationManager.AppSettings["SenhaEmail"];

            if (avaliacaoAberta.Count() > 0)
            {
                foreach (var avaliacao in avaliacaoAberta)
                {
                    if (avaliacao.dtInicio >= DateTime.Now || avaliacao.dtFim <= DateTime.Now)
                    {
                        foreach (var aluno in avaliacao.turma.Alunos)
                        {
                            var mensagem = new StringBuilder();

                            mensagem.AppendLine("Olá caro aluno, " + aluno.Nome + ", gostariamos de saber a sua opnião para melhorar nosso curso!");
                            mensagem.AppendLine("Segue abaixo o link com o questionário:");
                            mensagem.AppendLine("http://localhost/Avaliacao/Questionario");

                            //aluno.Email = _servicoAluno.BuscarPorId(aluno.Id).Email;
                            //EmailUtil.EnviarEmail(aluno.Email, "Avaliação Institucional", corpoMensagem,);
                            EmailUtil.EnviaEmail("Avaliação Institucional",email,"jonas.xiko.ribeiro@gmail.com",true,mensagem,smtp,senha);
                        }
                    }
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Visualizar(Guid id)
        {
            var avaliacao = _servicoAvaliacao.BuscarPorId(id);

            if (avaliacao == null)
            {
                return RedirectToAction("Erro", "Erro");
            }

            return View(avaliacao);
        }

        [HttpGet]
        public ActionResult Editar(Guid id)
        {
            var avaliacao = _servicoAvaliacao.BuscarPorId(id);
            avaliacao.IdTurma = avaliacao.turma.Id;

            if (avaliacao == null)
            {
                return RedirectToAction("Erro", "Erro");
            }

            ViewBag.TurmaID = _servicoTurma.ListarTodos();

            return View(avaliacao);
        }

        [HttpPost]
        public ActionResult Editar(AvaliacaoVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _servicoAvaliacao.Cadastrar(model);

                    ModelState.Clear();
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                modelState.Errors.Add(e.Message);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Remover(Guid id)
        {
            var avaliacao = _servicoAvaliacao.BuscarPorId(id);

            if (avaliacao == null)
                return RedirectToAction("Erro", "Erro");

            return View(avaliacao);
        }

        [HttpPost]
        public ActionResult Remover(AvaliacaoVM model)
        {
            try
            {
                _servicoAvaliacao.Remover(model);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                modelState.Errors.Add(e.Message);
                return View(model);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Questionario()
        {
            return View("Questionario");
        }

        #region Métodos compartilhados

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

        #endregion

    }
}