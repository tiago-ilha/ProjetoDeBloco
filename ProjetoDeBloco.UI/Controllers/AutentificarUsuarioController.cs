﻿using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjetoDeBloco.UI.Controllers
{
    public class AutentificarUsuarioController : Controller
    {
        private IUsuarioServico _servicoUsuario;

        public AutentificarUsuarioController(IUsuarioServico servicoUsuario)
        {
            _servicoUsuario = servicoUsuario;
        }

        public ActionResult Login()
        {
            ViewBag.titulo = "Área Restrita";
            return View();
        }

        [HttpGet]
        public JsonResult Logar(string login, string senha)
        {
            try
            {
                var usuarioLogado = _servicoUsuario.Logar(login, senha);

                if (usuarioLogado != null)
                {
                    //FormsAuthentication.SetAuthCookie(usuarioLogado.Login, false);

                    Session.Add("UsuarioLogado", usuarioLogado.Login);
                    Session.Timeout = 2;

                    return Json(new { ok = true, mensagem = "Usuário autenticado... Redirecionando!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { ok = false, mensagem = "Usuário não encontrando. Tente novamente." }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (DbException e)
            {
                return Json(new { OK = false, Mensagem = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }       
    }
}
