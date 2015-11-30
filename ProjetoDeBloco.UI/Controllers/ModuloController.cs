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
	public class ModuloController : BaseController
    {
        private readonly IModuloServico _servicoModulo;
        private readonly IBlocoServico _servicoBloco;
        private readonly IProfessorServico _servicoProfessor;

        public ModuloController(IModuloServico servicoModulo, IBlocoServico servicoBloco, IProfessorServico servicoProfessor)
        {
            _servicoModulo = servicoModulo;
            _servicoBloco = servicoBloco;
            _servicoProfessor = servicoProfessor;
        }

        public ActionResult Index()
        {
            var listaDeModulos = CarregarModulos();
            return View(listaDeModulos);
        }

        // GET: Modulo/Details/5
        public ActionResult Visualizar(Guid id)
        {
            var moduloVM = _servicoModulo.BuscarPorId(id);
            var blocoVM = _servicoBloco.BuscarPorId(moduloVM.IdBloco);

            if (blocoVM != null)
                moduloVM.Bloco = blocoVM;
            else
                moduloVM.Bloco.Nome = "--";

            return View(moduloVM);
        }

        // GET: Modulo/Create
        public ActionResult Cadastrar()
        {
            CarregarBlocos();
            CarregarProfessores();
            return View();
        }

        // POST: Modulo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(ModuloVM model)
        {
            if (!ModelState.IsValid)
                return View(model);        

            try
            {

                if (Request.Form["Blocos"] != "")
                {
                    var idBloco = Guid.Parse(Request.Form["Blocos"]);
                    model.Bloco = _servicoBloco.BuscarPorId(idBloco);
                }

                _servicoModulo.Cadastrar(model);

                ModelState.Clear();

                ViewBag.Blocos = new SelectList(_servicoBloco.ListarTodos(), "Id", "Nome", model.IdBloco);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }
        }

        // GET: Modulo/Edit/5
        public ActionResult Editar(Guid id)
        {
            var moduloVM = _servicoModulo.BuscarPorId(id);
            ViewBag.Blocos = new SelectList(_servicoBloco.ListarTodos(), "Id", "Nome", moduloVM.IdBloco);

            return View(moduloVM);
        }

        // POST: Modulo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ModuloVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                if (Request.Form["Blocos"] != "")
                {
                    var bloco = _servicoBloco.BuscarPorId(Guid.Parse(Request.Form["Blocos"])); ;
                    model.IdBloco = bloco.Id;
                }

                _servicoModulo.Cadastrar(model);

                ModelState.Clear();

                ViewBag.Blocos = new SelectList(_servicoBloco.ListarTodos(), "Id", "Nome", model.IdBloco);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }
        }

        // GET: Modulo/Delete/5
        public ActionResult Remover(Guid id)
        {
            var moduloVM = _servicoModulo.BuscarPorId(id);
            var blocoVM = _servicoBloco.BuscarPorId(moduloVM.IdBloco);

            if (blocoVM != null)
                moduloVM.Bloco = blocoVM;
            else
                moduloVM.Bloco.Nome = "--";

            return View(moduloVM);
        }

        // POST: Modulo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remover(ModuloVM modulo)
        {
            try
            {
                var moduloVM = _servicoModulo.BuscarPorId(modulo.Id);

                _servicoModulo.Remover(moduloVM);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        #region métodos compartilhados

        private IEnumerable<ModuloVM> CarregarModulos()
        {
            IList<ModuloVM> lista = new List<ModuloVM>();

            foreach (var item in _servicoModulo.ListarTodos())
            {
                ModuloVM model = new ModuloVM();

                var bloco = _servicoBloco.BuscarPorId(item.IdBloco);

                model.Id = item.Id;
                model.Nome = item.Nome;
                model.IdBloco = bloco.Id;
                model.Bloco = bloco;

                lista.Add(model);
            }

            return lista;
        }

        private void CarregarProfessores()
        {
            ViewBag.Professores = new SelectList(_servicoProfessor.ListarTodos(), "Id", "Nome");
        }

        private void CarregarBlocos()
        {
            ViewBag.Blocos = new SelectList(_servicoBloco.ListarTodos(), "Id", "Nome");
        }

        #endregion
    }
}
