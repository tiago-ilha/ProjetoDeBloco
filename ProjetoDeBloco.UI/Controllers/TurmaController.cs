using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDeBloco.UI.Controllers
{
    public class TurmaController : Controller
    {
        private readonly ITurmaServico _servicoTurma;
        private readonly IModuloServico _servicoModulo;
        private readonly IAlunoServico _servicoAluno;

        public TurmaController(ITurmaServico servicoTurma, IModuloServico servicoModulo, IAlunoServico servicoAluno)
        {
            _servicoTurma = servicoTurma;
            _servicoModulo = servicoModulo;
            _servicoAluno = servicoAluno;
        }

        // GET: Turma
        public ActionResult Index()
        {
            var turmas = _servicoTurma.ListarTodos();
            return View(turmas);
        }

        // GET: Turma/Details/5
        public ActionResult Visualizar(Guid id)
        {
            var turma = CarregarTurma(id);
            return View(turma);
        }

        // GET: Turma/Create
        public ActionResult Cadastrar()
        {
            CarregarModulos();
            return View();
        }

        // POST: Turma/Create
        [HttpPost]
        public ActionResult Cadastrar(TurmaVM model)
        {
            Guid idModulo;

            if (Request.Form["Modulos"] != "")
            {
                idModulo = Guid.Parse(Request.Form["Modulos"]);
                model.Modulo = _servicoModulo.BuscarPorId(idModulo);
            }
            else
            {
                idModulo = Guid.Empty;
                model.Modulo.Id = idModulo;
            }

            IList<AlunoVM> listaDeAlunos = new List<AlunoVM>();

            foreach (var item in model.Alunos)
            {
                var aluno = _servicoAluno.BuscarPorNome(item.Nome);
                //model.Alunos.Add(aluno);
                
                AlunoVM alunoVm = new AlunoVM
                {
                    Id = aluno.Id,
                    Matricula = aluno.Matricula,
                    Nome = aluno.Nome,
                    DataNascimento = aluno.DataNascimento
                };

                listaDeAlunos.Add(alunoVm);
            }

            model.Alunos = null; //com isso eu esvazio aquela lixarada
            model.Alunos = listaDeAlunos;

            try
            {
                if (!ModelState.IsValid)
                    return View();                

                _servicoTurma.Cadastrar(model);
                ModelState.Clear();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Modulos = new SelectList(_servicoModulo.ListarTodos(), "Id", "Nome", model.IdModulo);
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }

            CarregarModulos();
        }

        // GET: Turma/Edit/5
        public ActionResult Editar(Guid id)
        {
            return View();
        }

        // POST: Turma/Edit/5
        [HttpPost]
        public ActionResult Editar(int id, FormCollection collection)
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

        // GET: Turma/Delete/5
        public ActionResult Remover(Guid id)
        {
            return View();
        }

        // POST: Turma/Delete/5
        [HttpPost]
        public ActionResult Remover(int id, FormCollection collection)
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

        #region Metodos Compartilhados

        private TurmaVM CarregarTurma(Guid id)
        {
            var turma = _servicoTurma.BuscarPorId(id);
            return turma;
        }

        private void CarregarModulos()
        {
            ViewBag.Modulos = new SelectList(_servicoModulo.ListarTodos(), "Id", "Nome");
        }

        #endregion
    }
}
