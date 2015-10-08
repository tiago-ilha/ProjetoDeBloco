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

        public AvaliacaoController(IAvaliacaoServico servicoAvaliacao, ITurmaServico servicoTurma)
        {
            _servicoAvaliacao = servicoAvaliacao;

            _servicoTurma = servicoTurma;
        }
        //
        // GET: /Avaliacao/
        public ActionResult Index()
        {

            var listaAvaliacao = CarregaAvaliacao();


            return View(listaAvaliacao);
        }


        public ActionResult Cadastrar()
        {
            carrregaTurma();

            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(AvaliacaoVM avaliacao)
        {
            _servicoAvaliacao.Cadastrar(avaliacao);

            ModelState.Clear();

            return RedirectToAction("Index");
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