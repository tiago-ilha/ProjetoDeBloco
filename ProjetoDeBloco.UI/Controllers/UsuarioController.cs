using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDeBloco.UI.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioServico _servicoUsuario;

        public UsuarioController(IUsuarioServico servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public PartialViewResult Cadastro()
        {
            return PartialView();
        }

        // POST: Usuario/Create
         [HttpGet]
        public JsonResult Cadastro(UsuarioVM model)
        {
            try
            {
                _servicoUsuario.Cadastrar(model);     
           
                 return Json(new { ok = true, mensagem = "Operação realizada com sucesso!" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { ok = false, mensagem = "Não foi possivel realizar a operação!" }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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
