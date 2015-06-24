using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDeBloco.UI.Controllers
{
    public class BlocoController : Controller
    {
        private IBlocoServico _servicoBloco;
        private ICursoServico _servicoCurso;

        public BlocoController(IBlocoServico servicoBloco, ICursoServico servicoCurso)
        {
            _servicoBloco = servicoBloco;
            _servicoCurso = servicoCurso;
        }

        // GET: Bloco
        public ActionResult Index()
        {
            var listaDeBlocos = CarregarBlocosParaTabela();
            return View(listaDeBlocos);
        }


        // GET: Bloco/Details/5
        public ActionResult Visualizar(Guid id)
        {
            var blocoVM = _servicoBloco.BuscarPorId(id);
            return View(blocoVM);
        }

        // GET: Bloco/Create
        public ActionResult Cadastrar()
        {
            CarregarCurso();

            return View();
        }

        // POST: Bloco/Create
        [HttpPost]
        public ActionResult Cadastrar(BlocoVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                model.IdCurso = Guid.Parse(Request.Form["CursoId"]);

                _servicoBloco.Cadastrar(model);

                ModelState.Clear();

                ViewBag.CursoId = new SelectList(_servicoCurso.ListarTodos(), "Id", "Nome", model.IdCurso);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }
        }

        // GET: Bloco/Edit/5
        public ActionResult Editar(Guid id)
        {
            var blocoVM = _servicoBloco.BuscarPorId(id);
            return View(blocoVM);
        }

        // POST: Bloco/Edit/5
        [HttpPost]
        public ActionResult Editar(BlocoVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                _servicoBloco.Cadastrar(model);

                ViewBag.CursoId = new SelectList(_servicoCurso.ListarTodos(), "Id", "Nome", model.IdCurso);

                ModelState.Clear();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }
        }

        // GET: Bloco/Delete/5
        public ActionResult Remover(Guid id)
        {
            var blocoVM = _servicoBloco.BuscarPorId(id);

            if (blocoVM == null)
                HttpNotFound();

            return View(blocoVM);
        }

        // POST: Bloco/Delete/5
        [HttpPost]
        public ActionResult Remover(BlocoVM model)
        {
            try
            {
                var blocoVM = _servicoBloco.BuscarPorId(model.Id);

                _servicoBloco.Remover(blocoVM);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        #region "Métodos compartilhados"

        private IEnumerable<BlocoVM> CarregarBlocosParaTabela()
        {
            IList<BlocoVM> lista = new List<BlocoVM>();

            foreach (var item in _servicoBloco.ListarTodos())
            {
                BlocoVM model = new BlocoVM();

                model.Id = item.Id;
                model.Nome = item.Nome;
                model.IdCurso = item.IdCurso;

                model.Curso = new CursoVM();
                model.Curso.Codigo = item.Curso.Codigo;
                model.Curso.Nome = item.Curso.Nome;

                lista.Add(model);
            }

            return lista;
        }

        private void CarregarCurso()
        {
            ViewBag.CursoId = new SelectList(_servicoCurso.ListarTodos(), "Id", "CodigoENome");
        }

        #endregion
    }
}
