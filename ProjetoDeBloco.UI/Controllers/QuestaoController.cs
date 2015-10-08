using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDeBloco.UI.Controllers
{
    public class QuestaoController : Controller
    {
        private IQuestaoServico _servico;

        public QuestaoController(IQuestaoServico servico)
        {
            _servico = servico;
        }

        //
        // GET: /Questao/
        public ActionResult Index()
        {
            var listaDeCursos = CarregarQuestoes();
            return View(listaDeCursos);
        }

        private IEnumerable<QuestaoVM> CarregarQuestoes()
        {
            IList<QuestaoVM> lista = new List<QuestaoVM>();

            foreach (var item in _servico.ListarTodos())
            {
                QuestaoVM model = new QuestaoVM();

                model.Id = item.Id;
                model.PerguntaQuestao = item.PerguntaQuestao;
                model.Resposta1 = item.Resposta1;
                model.Resposta2 = item.Resposta2;
                model.Resposta3 = item.Resposta3;
                model.Resposta4 = item.Resposta4;
                model.Resposta5 = item.Resposta5;
;

                lista.Add(model);
            }

            return lista;
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(QuestaoVM questao)
        {
            if (!ModelState.IsValid)
                return View(questao);

            _servico.Cadastrar(questao);

            ModelState.Clear();

            return RedirectToAction("Index");
        }

        public ActionResult Remover(Guid id)
        {
            var questaoVM = _servico.BuscarPorId(id);

            if (questaoVM == null)
                return HttpNotFound();

            return View(questaoVM);
        }

        // POST: Curso/Delete/5
        [HttpPost, ActionName("Remover")]
        public ActionResult RemoverConfirmado(Guid id)
        {
            try
            {
                var cursoVM = _servico.BuscarPorId(id);

                _servico.Remover(cursoVM);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("erroAoExcluir", ex.Message);
                return View();
            }
        }
	}
}