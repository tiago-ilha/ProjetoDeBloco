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
		private IUsuarioServico _servicoUsuario;

		public UsuarioController(IUsuarioServico servicoUsuario)
		{
			_servicoUsuario = servicoUsuario;
		}

		//
		// GET: /Usuario/
		public ActionResult Index()
		{
			return View(_servicoUsuario.ListarTodos());
		}

		//
		// GET: /Usuario/Details/5
		public ActionResult Details(Guid id)
		{
			var usuario = _servicoUsuario.BuscarPorId(id);

			return View(usuario);
		}

		//
		// GET: /Usuario/Create
		public ActionResult Create()
		{
			return View();
		}

		//
		// POST: /Usuario/Create
		[HttpPost]
		public ActionResult Create(UsuarioVM model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_servicoUsuario.Cadastrar(model);
				}

				return RedirectToAction("Index");
			}
			catch
			{
				return View(model);
			}
		}

		//
		// GET: /Usuario/Edit/5
		public ActionResult Edit(Guid id)
		{
			var usuario = _servicoUsuario.BuscarPorId(id);

			return View(usuario);
		}

		//
		// POST: /Usuario/Edit/5
		[HttpPost]
		public ActionResult Edit(UsuarioVM model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_servicoUsuario.Cadastrar(model);
				}

				return RedirectToAction("Index");
			}
			catch
			{
				return View(model);
			}
		}

		//
		// GET: /Usuario/Delete/5
		public ActionResult Delete(Guid id)
		{
			var usuario = _servicoUsuario.BuscarPorId(id);

			return View(usuario);
		}

		//
		// POST: /Usuario/Delete/5
		[HttpPost]
		public ActionResult Delete(UsuarioVM model)
		{
			try
			{
				_servicoUsuario.Remover(model);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(model);
			}
		}
	}
}
