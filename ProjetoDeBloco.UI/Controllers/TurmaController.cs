using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using ProjetoDeBloco.UI.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoDeBloco.UI.Controllers
{
    [AutentificacaoFiltro]
	public class TurmaController : BaseController
    {
        private readonly ITurmaServico _servicoTurma;
        private readonly IModuloServico _servicoModulo;
        private readonly IAlunoServico _servicoAluno;
        private readonly IProfessorServico _servicoProfessor;

        public TurmaController(ITurmaServico servicoTurma,
            IModuloServico servicoModulo,
            IAlunoServico servicoAluno,
            IProfessorServico servicoProfessor)
        {
            _servicoTurma = servicoTurma;
            _servicoModulo = servicoModulo;
            _servicoAluno = servicoAluno;
            _servicoProfessor = servicoProfessor;
        }

        // GET: Turma
        public ActionResult Index()
        {
            TurmaVM turmas;
            var listaDeTurmas = new List<TurmaVM>();

            foreach (var item in _servicoTurma.ListarTodos())
            {
                turmas = new TurmaVM();
                turmas.Id = item.Id;
                turmas.Identificador = item.Identificador;
                turmas.Modulo = _servicoModulo.BuscarPorId(item.Modulo.Id);
                turmas.Professor = _servicoProfessor.BuscarPorId(item.IdProfessor);
                turmas.Alunos = item.Alunos;

                listaDeTurmas.Add(turmas);
            }

            return View(listaDeTurmas);
        }

        // GET: Turma/Details/5
        public ActionResult Visualizar(Guid id)
        {
            var turma = CarregarTurma(id);
            return View(turma);
        }

        #region Cadastro
        // GET: Turma/Create
        public ActionResult Cadastrar()
        {
            CarregarModulos();
            CarregarProfessor();
            return View();
        }

        // POST: Turma/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(TurmaVM model)
        {
            Guid idModulo;
            Guid idProfessor;

            CarregarDadosDoModulo(model);
            CarregarDadosDoProfessor(model);

            MontarDadosDeTurma(model);

            try
            {
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
            CarregarProfessor();
        }

        private void MontarDadosDeTurma(TurmaVM model)
        {
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
                    Email = aluno.Email,
                    DataNascimento = aluno.DataNascimento
                };

                listaDeAlunos.Add(alunoVm);
            }

            model.Alunos = null; //com isso eu esvazio aquela lixarada
            model.Alunos = listaDeAlunos;
        }

        #endregion

        #region Editar
        // GET: Turma/Edit/5
        public ActionResult Editar(Guid id)
        {
            var turma = CarregarDadosDaTurma(id);
            return View(turma);
        }

        private TurmaVM CarregarDadosDaTurma(Guid id)
        {
            var turmaVM = _servicoTurma.BuscarPorId(id);
            return turmaVM;
        }

        // POST: Turma/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        #endregion

        #region Remover
        // GET: Turma/Delete/5
        public ActionResult Remover(Guid id)
        {
            return View();
        }

        // POST: Turma/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
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

        #endregion

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

        private void CarregarProfessor()
        {
            ViewBag.Professores = new SelectList(_servicoProfessor.ListarTodos(), "Id", "Nome");
        }

        private void CarregarDadosDoProfessor(TurmaVM model)
        {
            Guid idProfessor;
            if (Request.Form["Professores"] != "")
            {
                idProfessor = Guid.Parse(Request.Form["Professores"]);
                model.IdProfessor = idProfessor;
                model.Professor = _servicoProfessor.BuscarPorId(model.IdProfessor);
            }
            else
            {
                idProfessor = Guid.Empty;
                model.Professor.Id = idProfessor;
            }
        }

        private void CarregarDadosDoModulo(TurmaVM model)
        {
            Guid idModulo;
            if (Request.Form["Modulos"] != "")
            {
                idModulo = Guid.Parse(Request.Form["Modulos"]);
                model.IdModulo = idModulo;
                model.Modulo = _servicoModulo.BuscarPorId(model.IdModulo);
            }
            else
            {
                idModulo = Guid.Empty;
                model.Modulo.Id = idModulo;
            }
        }

        #endregion
    }
}
