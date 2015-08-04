using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDeBloco.UI.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ITurmaServico _servicoTurma;
        private readonly IModuloServico _servicoModulo;

        public TurmaController(ITurmaServico servicoTurma, IModuloServico servicoModulo)
        {
            _servicoTurma = servicoTurma;
            _servicoModulo = servicoModulo;
        }

        // GET: Turma
        public ActionResult Index()
        {
            var turmas = _servicoTurma.ListarTodos();
            return View(turmas);
        }

        // GET: Turma/Details/5
        public ActionResult Visualizar(Guid id)
        {
            var turma = CarregarTurma(id);
            return View(turma);
        }        

        // GET: Turma/Create
        public ActionResult Cadastrar()
        {
            CarregarModulos();
            return View();
        }       

        // POST: Turma/Create
        [HttpPost]
        public ActionResult Cadastrar(TurmaVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                _servicoTurma.Cadastrar(model);

                ModelState.Clear();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Turma/Edit/5
        public ActionResult Editar(Guid id)
        {
            return View();
        }

        // POST: Turma/Edit/5
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

        // GET: Turma/Delete/5
        public ActionResult Remover(Guid id)
        {
            return View();
        }

        // POST: Turma/Delete/5
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

        #region Metodos Compartilhados

        private TurmaVM CarregarTurma(Guid id)
        {
            var turma = _servicoTurma.BuscarPorId(id);
            return turma;
        }

        private void CarregarModulos()
        {
            ViewBag.Modulos = new SelectList(_servicoModulo.ListarTodos(), "Id", "Nome");
        }

        #endregion
    }
}
