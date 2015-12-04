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
				modelState.Errors.Add(e.Message);
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
			catch (Exception e)
			{
				modelState.Errors.Add(e.Message);
				return View(model);
			}
		}

		// GET: Administrador/Delete/5
		[HttpGet]
		public ActionResult Deletar(Guid id)
		{
			var administrador = _servicoAdministrador.BuscarPorId(id);

			if (administrador == null)
				return RedirectToAction("Erro", "Erro");

			return View(administrador);
		}

		// POST: Administrador/Delete/5
		[HttpPost]
		public ActionResult Deletar(AdministradorVM model)
		{
			try
			{
				if(model.Usuario != null && model.Usuario.Id == Guid.Empty)
				{
					var administrador = _servicoAdministrador.BuscarPorId(model.Id);

					model.Usuario = administrador.Usuario;
				}

				_servicoAdministrador.Remover(model);

				return RedirectToAction("Index");
			}
			catch (Exception e)
			{
				modelState.Errors.Add(e.Message);
				return View(model);
			}
		}
	}
}
