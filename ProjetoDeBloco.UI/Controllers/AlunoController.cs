<<<<<<< HEAD
﻿using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDeBloco.UI.Controllers
{
    public class AlunoController : Controller
    { 
        private IAlunoServico _servico;

        public AlunoController(IAlunoServico servico)
        {
            _servico = servico; 
        }

        // GET: Aluno
        public ActionResult Index()
        {
            var alunos = _servico.ListarTodos();
            return View(alunos);
        }

        // GET: Aluno/Details/5
        public ActionResult Visualizar(Guid id)
        {
            var aluno = _servico.BuscarPorId(id);
            return View(aluno);
        }

        // GET: Aluno/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        public ActionResult Cadastrar(AlunoVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _servico.Cadastrar(model);

                ModelState.Clear();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }
        }

        // GET: Aluno/Edit/5
        public ActionResult Editar(Guid id)
        {
            var aluno = _servico.BuscarPorId(id);
            return View(aluno);
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        public ActionResult Editar(AlunoVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _servico.Cadastrar(model);

                ModelState.Clear();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }
        }

        // GET: Aluno/Delete/5
        public ActionResult Remover(Guid id)
        {
            var aluno = _servico.BuscarPorId(id);
            return View(aluno);
        }

        // POST: Aluno/Delete/5
        [HttpPost]
        public ActionResult Remover(AlunoVM model)
        {
            try
            {
                _servico.Remover(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }
        }

        [HttpGet]        
        public JsonResult Listar()
        {
            var resultado = (from aluno in _servico.ListarTodos()
                             orderby aluno.Nome
                             select new { id = aluno.Id, nome = aluno.Nome }).Distinct().ToList();

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}
=======
﻿using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDeBloco.UI.Controllers
{
    public class AlunoController : Controller
    { 
        private IAlunoServico _servico;

        public AlunoController(IAlunoServico servico)
        {
            _servico = servico; 
        }

        // GET: Aluno
        public ActionResult Index()
        {
            var alunos = _servico.ListarTodos();
            return View(alunos);
        }

        // GET: Aluno/Details/5
        public ActionResult Visualizar(Guid id)
        {
            var aluno = _servico.BuscarPorId(id);
            return View(aluno);
        }

        // GET: Aluno/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        public ActionResult Cadastrar(AlunoVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _servico.Cadastrar(model);

                ModelState.Clear();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }
        }

        // GET: Aluno/Edit/5
        public ActionResult Editar(Guid id)
        {
            var aluno = _servico.BuscarPorId(id);
            return View(aluno);
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        public ActionResult Editar(AlunoVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _servico.Cadastrar(model);

                ModelState.Clear();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }
        }

        // GET: Aluno/Delete/5
        public ActionResult Remover(Guid id)
        {
            var aluno = _servico.BuscarPorId(id);
            return View(aluno);
        }

        // POST: Aluno/Delete/5
        [HttpPost]
        public ActionResult Remover(AlunoVM model)
        {
            try
            {
                _servico.Remover(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }
        }

        [HttpGet]        
        public JsonResult Listar()
        {
            var resultado = (from aluno in _servico.ListarTodos()
                             orderby aluno.Nome
                             select new { id = aluno.Id, nome = aluno.Nome , email = aluno.Email}).Distinct().ToList();

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
    }
}
>>>>>>> 783aa6575c0558e368e19a68b44aeb2233109a24
