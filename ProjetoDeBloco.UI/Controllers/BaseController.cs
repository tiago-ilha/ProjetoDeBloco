using ProjetoDeBloco.Aplicacao.ViewModels;
using ProjetoDeBloco.Dominio.Entidades.Administracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDeBloco.UI.Controllers
{
	public class BaseController : Controller
	{
		public string UsuarioLogado
		{
			get
			{
                return (string)Session["usuarioLogado"];
			}
			set
			{
				Session["usuarioLogado"] = value;
			}
		}

        public int idUsuario
        {
            get
            {
                return (int)Session["IdUsuario"];
            }
            set
            {
                Session["IdUsuario"] = value;
            }
        }

		protected ModelState modelState = new ModelState();
	}
}