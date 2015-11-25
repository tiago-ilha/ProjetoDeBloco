using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;

namespace ProjetoDeBloco.UI.Controllers
{
    public class AdministradorController : Controller
    {
        private IAdministradorServico _servicoAdministrador;

        public AdministradorController(IAdministradorServico servicoAdministrador)
        {
            _servicoAdministrador = servicoAdministrador;
        }

        // GET: Administrador
        public ActionResult Index(int? pagina)
        {
            int tamanhoPagina = 10;
            int numeroPagina = pagina ?? 1;

            return View(_servicoAdministrador.ListarTodos().ToPagedList(numeroPagina, tamanhoPagina));
        }

        // GET: Administrador/Details/5
        public ActionResult Details(Guid id)
        {
             var administrador = _servicoAdministrador.BuscarPorId(id);

            return View(administrador);
        }

        // GET: Administrador/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Administrador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        // GET: Administrador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Administrador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: Administrador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Administrador/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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
