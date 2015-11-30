using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.UI.Filtros;
using ProjetoDeBloco.Aplicacao.ViewModels;
using ProjetoDeBloco.Aplicacao.Excecoes;

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
		[HttpGet]
		public ActionResult Cadastrar()
		{
			return View();
		}

		// POST: Administrador/Create
		[HttpPost]
		//[ValidateAntiForgeryToken]
		public JsonResult Cadastrar(AdministradorVM model)
		{
			try
			{			
				_servicoAdministrador.Cadastrar(model);

				return Json(new { OK = true, mensagem = "Operação foi realizada com sucesso!" }, JsonRequestBehavior.AllowGet);
			}
			catch (UsuarioJaCadastradoExcecao e)
			{
				return Json(new { OK = false, Mensagem = e.Message }, JsonRequestBehavior.AllowGet);
			}
			catch(Exception e)
			{
				return Json(new { OK = false, Mensagem = e.Message }, JsonRequestBehavior.AllowGet);
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
