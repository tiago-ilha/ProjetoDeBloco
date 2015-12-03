using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Utilitarios.Seguranca;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjetoDeBloco.UI.Controllers
{
	public class AutentificarUsuarioController : BaseController
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
				var usuarioLogado = _servicoUsuario.Logar(login, Criptografia.CriptografaSenha(senha));

				if (usuarioLogado)
				{
					var usuario = _servicoUsuario.ObterUsuarioPeloLogin(login);

					if (Session["usuarioLogado"] == null)
						Session.Add("usuarioLogado", usuario.Login);

					return Json(new { ok = true, mensagem = "Usuário autenticado... Redirecionando!" }, JsonRequestBehavior.AllowGet);
				}
				else
				{
					return Json(new { ok = false, mensagem = "Usuário ou senha inválidos! Tente novamente." }, JsonRequestBehavior.AllowGet);
				}
			}
			catch (DbException e)
			{
				return Json(new { OK = false, Mensagem = e.Message }, JsonRequestBehavior.AllowGet);
			}
		}

		[HttpGet]
		public JsonResult Deslogar()
		{
			if (Session["usuarioLogado"] != null)
			{
				Session.Remove("usuarioLogado");
				Session.Clear();
				Session.Abandon();
			}

			return Json(new { ok = true, mensagem = "Usuário deslogado!" }, JsonRequestBehavior.AllowGet);
		}
	}
}
