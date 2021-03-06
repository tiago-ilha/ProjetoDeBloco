﻿using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
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
	public class QuestaoController : BaseController
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

        public ActionResult Visualizar(Guid id)
        {
            var questaoVm = _servico.BuscarPorId(id);

            if (questaoVm == null)
                return HttpNotFound();

            return View(questaoVm);
        }


        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(QuestaoVM questao)
        {
            if (!ModelState.IsValid)
                return View(questao);

            _servico.Cadastrar(questao);

            ModelState.Clear();

            return RedirectToAction("Index");
        }

        public ActionResult Editar(Guid id)
        {
            var questaoVm = _servico.BuscarPorId(id);

            if (questaoVm == null)
                return HttpNotFound();

            return View(questaoVm);
        }

        [HttpPost]
        public ActionResult Editar(QuestaoVM questao)
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
        [ValidateAntiForgeryToken]
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

        [HttpGet]
        public JsonResult Listar()
        {
            var resultado = (from questao in _servico.ListarTodos()
                             orderby questao.PerguntaQuestao
                             select new { id = questao.Id, nome = questao.PerguntaQuestao }).Distinct().ToList();

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
	}
}