using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDeBloco.UI.Controllers
{
    public class AvaliacaoController : Controller
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

            //foreach (var item in model.Questoes)
          //  {
           //      var questao = _servicoQuestao.BuscarPorId(item.Id);
            //    //model.Alunos.Add(aluno);

            //    AlunoVM alunoVm = new AlunoVM
            //    {
            //        Id = aluno.Id,
            //        Matricula = aluno.Matricula,
            //        Nome = aluno.Nome,
            //        DataNascimento = aluno.DataNascimento
            //    };

            //    listaDeAlunos.Add(alunoVm);
         //   }

            //model.Alunos = null; //com isso eu esvazio aquela lixarada
            //model.Alunos = listaDeAlunos;
        }

        private void CarregarTurma()
        {
            ViewBag.Turmas = new SelectList(_servicoTurma.ListarTodos(), "Id", "Identificador");
        }

        private void CarregarDadosDaTurma(AvaliacaoVM model)
        {
            //Guid idTurma;
            //if (Request.Form["TurmaID"] != "")
            //{
            //    idTurma = Guid.Parse(Request.Form["TurmaID"]);
            //    model.IdTurma = idTurma;
            //}
            //else
            //{
            //    idTurma = Guid.Empty;
            //    model.turma.Id = idTurma;
            //}


            Guid idTurma;
            if (Request.Form["TurmaID"] != "")
            {
                idTurma = Guid.Parse(Request.Form["TurmaID"]);
                model.turma = _servicoTurma.BuscarPorId(idTurma);
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