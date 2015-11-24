using ProjetoDeBloco.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjetoDeBloco.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UsuarioLogado"] != null)
            {
                ViewBag.UsuarioLogado = Session["UsuarioLogado"].ToString().ToUpper();
            }          

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}