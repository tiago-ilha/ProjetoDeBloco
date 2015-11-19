using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDeBloco.UI.Controllers
{
    public class AutentificarUsuarioController : Controller
    {
        //private IUsuarioServico _servicoUsuario;

        //public AutentificarUsuarioController(IUsuarioServico servicoUsuario)
        //{
        //    _servicoUsuario = servicoUsuario;
        //}

        public ActionResult Login()
        {
            ViewBag.titulo = "Área Restrita";
            return View();
        }

        [HttpGet]
        public JsonResult AutentificarUsuario(string login, string senha)
        {

            return Json(new { ok = true, Mensagem = "Usuário autenticado... Redirecionando!" }, JsonRequestBehavior.AllowGet);
        //{
        //    try
        //    //{
        //    //    var usuarioLogado = _servicoUsuario.Logar(login, senha);

        //        if (usuarioLogado != null)
        //        {
        //            Session["UsuarioLogado"] = usuarioLogado.Login;

        //            return Json(new { ok = true, Mensagem = "Usuário autenticado... Redirecionando!" }, JsonRequestBehavior.AllowGet);
        //        }
        //        else
        //        {
        //            return Json(new { OK = false, Mensagem = "Usuário não encontrando. Tente novamente." }, JsonRequestBehavior.AllowGet);
        //        }
                
        //    }
        //    catch (DbException e)
        //    {
        //        return Json(new { OK = false, Mensagem = e.Message }, JsonRequestBehavior.AllowGet);
        //    }
        }        
    }
}
