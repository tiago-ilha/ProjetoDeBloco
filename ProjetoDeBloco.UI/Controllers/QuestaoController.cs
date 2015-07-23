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
        // GET: Questao
        public ActionResult Index()
        {
            return View();
        }

        // GET: Questao/Details/5
        public ActionResult Visualizar(int id)
        {
            return View();
        }

        // GET: Questao/Create
        public ActionResult Cadastrar(RespostasDasQuestoes model)
        {


            return View();
        }

        // POST: Questao/Create
        [HttpPost]
        public ActionResult Cadastrar(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Questao/Edit/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: Questao/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Questao/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Questao/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
