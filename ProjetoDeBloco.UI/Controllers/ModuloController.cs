using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDeBloco.UI.Controllers
{
    public class ModuloController : Controller
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
        public ActionResult Cadastrar(ModuloVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var idBloco = Request.Form["IdBloco"];

                //model.Bloco.Id = _servicoBloco.BuscarPorId(idBloco);
                model.ProfessorTitular.Id = Guid.Parse(Request.Form["IdProfessor"]);

                _servicoModulo.Cadastrar(model);

                ModelState.Clear();

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }
        }

        // GET: Modulo/Edit/5
        public ActionResult Editar(int id)
        {
            return View();
        }

        // POST: Modulo/Edit/5
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

        // GET: Modulo/Delete/5
        public ActionResult Remover(Guid id)
        {
            return View();
        }

        // POST: Modulo/Delete/5
        [HttpPost]
        public ActionResult Remover(ModuloVM modulo)
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


        #region métodos compartilhados

        private IEnumerable<ModuloVM> CarregarModulos()
        {
            IList<ModuloVM> lista = new List<ModuloVM>();

            foreach (var item in _servicoModulo.ListarTodos())
            {
                ModuloVM model = new ModuloVM();

                model.Id = item.Id;
                model.Nome = item.Nome;
                model.Bloco.Nome = item.Bloco.Nome;
                model.ProfessorTitular.Nome = item.ProfessorTitular.Nome;

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
