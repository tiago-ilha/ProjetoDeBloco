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
	public class ProfessorController : BaseController
    {
        private readonly IProfessorServico _servicoProfessor;

        public ProfessorController(IProfessorServico servicoProfessor)
        {
            _servicoProfessor = servicoProfessor;
        }

        public ActionResult Index()
        {
            var professores = _servicoProfessor.ListarTodos();
            return View(professores);
        }

        public ActionResult Visualizar(Guid id)
        {
            var professor = CarregarProfessor(id);

            if(professor == null)
                return RedirectToAction("Erro", "Erro");

            return View(professor);
        }
        

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(ProfessorVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _servicoProfessor.Cadastrar(model);

                ModelState.Clear();
                
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }
        }

        public ActionResult Editar(Guid id)
        {
            var professor = CarregarProfessor(id);

            if(professor == null)
                return RedirectToAction("Erro", "Erro");

            return View(professor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ProfessorVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _servicoProfessor.Cadastrar(model);

                ModelState.Clear();

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }
        }

        public ActionResult Remover(Guid id)
        {
            var professor = CarregarProfessor(id);

            if(professor == null)
                return RedirectToAction("Erro", "Erro");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remover(ProfessorVM model)
        {
            try
            {
                _servicoProfessor.Remover(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }
        }


        private ProfessorVM CarregarProfessor(Guid id)
        {
            var professor = _servicoProfessor.BuscarPorId(id);
            return professor;
        }
    }
}
