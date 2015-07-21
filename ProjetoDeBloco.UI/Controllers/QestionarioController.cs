using ProjetoDeBloco.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDeBloco.UI.Controllers
{
    public class QestionarioController : Controller
    {
        // GET: Qestionario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Qestionario/Details/5
        public ActionResult Visualizar(Guid id)
        {
            return View();
        }

        // GET: Qestionario/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Qestionario/Create
        [HttpPost]
        public ActionResult Cadastrar(QuestionarioVM model)
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

        // GET: Qestionario/Edit/5
        public ActionResult Editar(Guid id)
        {
            return View();
        }

        // POST: Qestionario/Edit/5
        [HttpPost]
        public ActionResult Editar(QuestionarioVM model)
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

        // GET: Qestionario/Delete/5
        public ActionResult Remover(int id)
        {
            return View();
        }

        // POST: Qestionario/Delete/5
        [HttpPost]
        public ActionResult Remover(int id, FormCollection collection)
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
