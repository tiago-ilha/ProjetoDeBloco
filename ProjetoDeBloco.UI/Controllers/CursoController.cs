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
    public class CursoController : Controller 
    {
        private ICursoServico _servico;

        public CursoController(ICursoServico servico)
        {
            _servico = servico;
        }

        // GET: Curso
        public ActionResult Index()
        {
            var listaDeCursos = CarregarCursos();
            return View(listaDeCursos);
        }

        // GET: Curso/Details/5
        public ActionResult Visualizar(Guid id)
        {
            var cursoVM = _servico.BuscarPorId(id);
            return View(cursoVM);
        }

        // GET: Curso/Create
        public ActionResult Cadastro()
        {
            return View();
        }

        // POST: Curso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(CursoVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                _servico.Cadastrar(model);

                ModelState.Clear();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }
        }

        // GET: Curso/Edit/5
        public ActionResult Editar(Guid id)
        {
            var cursoVM = _servico.BuscarPorId(id);
            return View(cursoVM);
        }

        // POST: Curso/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CursoVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                _servico.Cadastrar(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }
        }

        // GET: Curso/Delete/5
        public ActionResult Remover(Guid id)
        {
            var cursoVM = _servico.BuscarPorId(id);

            if (cursoVM == null)
                return HttpNotFound();

            return View(cursoVM);
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

        protected override void Dispose(bool disposing)
        {
            _servico.Dispose();
        }

        #region Métodos compartilhados

        private IEnumerable<CursoVM> CarregarCursos()
        {
            IList<CursoVM> lista = new List<CursoVM>();

            foreach (var item in _servico.ListarTodos())
            {
                CursoVM model = new CursoVM();

                model.Id = item.Id;
                model.Codigo = item.Codigo;
                model.Nome = item.Nome;                

                lista.Add(model);
            }

            return lista;
        }

        #endregion
    }
}
