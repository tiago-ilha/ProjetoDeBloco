using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.UI.Filtros;
using ProjetoDeBloco.Aplicacao.ViewModels;

namespace ProjetoDeBloco.UI.Controllers
{
    [AutentificacaoFiltro]
    public class AdministradorController : BaseController
    {
        private IAdministradorServico _servicoAdministrador;

        public AdministradorController(IAdministradorServico servicoAdministrador)
        {
            _servicoAdministrador = servicoAdministrador;
        }

        // GET: Administrador
        public ActionResult Index()
        {
            var administrador = _servicoAdministrador.ListarTodos();

            return View(administrador);
        }

        // GET: Administrador/Details/5
        [HttpGet]
        public ActionResult Visualizar(Guid id)
        {
            var administrador = _servicoAdministrador.BuscarPorId(id);

            if (administrador == null)
                return RedirectToAction("Erro", "Erro");

            return View(administrador);
        }

        // GET: Administrador/Create
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Administrador/Create
        [HttpPost]
        public ActionResult Cadastrar(AdministradorVM model)
        {
            try
            {
                _servicoAdministrador.Cadastrar(model);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("listaDeErros", e.Message);
                return View(model);
            }
        }

        // GET: Administrador/Edit/5
        [HttpGet]
        public ActionResult Editar(Guid id)
        {
            var administrador = _servicoAdministrador.BuscarPorId(id);

            if (administrador == null)
                return RedirectToAction("Erro", "Erro");

            return View(administrador);
        }

        //// POST: Administrador/Edit/5
        [HttpPost]
        public ActionResult Editar(AdministradorVM model)
        {
            try
            {
                model.Email = model.Usuario.Email;

                _servicoAdministrador.Cadastrar(model);

                return RedirectToAction("Index");
            }
            catch
            {               
                return View(model);
            }
        }

        // GET: Administrador/Delete/5
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            try
            {
                var administrador = _servicoAdministrador.BuscarPorId(id);

                if (administrador != null)
                    return Json(new { OK = true, resultado = administrador }, JsonRequestBehavior.AllowGet);
                else
                    return Json(new { OK = false, resultado = "" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return Json(new { OK = false, Mensagem = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // POST: Administrador/Delete/5
        [HttpPost]
        public ActionResult Remover(AdministradorVM model)
        {
            try
            {
                _servicoAdministrador.Remover(model);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("listaDeErros", e.Message);
                return Json(new { OK = false, resultado = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
