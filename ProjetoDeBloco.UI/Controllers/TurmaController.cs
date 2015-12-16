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

        #region Listagem
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
                turmas.Professor = _servicoProfessor.BuscarPorId(item.Professor.Id);
                turmas.Alunos = item.Alunos;

                listaDeTurmas.Add(turmas);
            }

            return View(listaDeTurmas);
        }

        #endregion

        #region Visualização

        // GET: Turma/Details/5
        public ActionResult Visualizar(Guid id)
        {
            var turma = CarregarTurma(id);

            return View(turma);
        }

        #endregion

        #region Cadastro
        // GET: Turma/Create
        public ActionResult Cadastrar()
        {
            CarregarModulo();
            CarregarProfessor();
            return View();
        }

        // POST: Turma/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(TurmaVM model)
        {
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

            CarregarModulo();
            CarregarProfessor();
        }

        #endregion

        #region Editar
        // GET: Turma/Edit/5
        public ActionResult Editar(Guid id)
        {
            var turma = _servicoTurma.BuscarPorId(id);
            ViewBag.Modulo = new SelectList(_servicoModulo.ListarTodos(),"Id","Nome",turma.Modulo.Id);
            ViewBag.Professor = new SelectList(_servicoProfessor.ListarTodos(), "Id", "Nome", turma.Professor.Id);

            return View(turma);
        }

        // POST: Turma/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(TurmaVM model)
        {
            if (Request.Form["Modulo"] != null)
            {
                Guid idModulo = Guid.Parse(Request.Form["Modulo"]);
                model.IdModulo = idModulo;
                model.Modulo = _servicoModulo.BuscarPorId(model.IdModulo);
            }

            if (Request.Form["Professor"] != null)
            {
                Guid idProfessor = Guid.Parse(Request.Form["Professor"]);
                model.IdProfessor = idProfessor;
                model.Professor = _servicoProfessor.BuscarPorId(model.IdProfessor);
            }

            MontarDadosDeTurma(model);

            try
            {
                _servicoTurma.Cadastrar(model);
                ModelState.Clear();

                return RedirectToAction("Index");
            }
             catch (Exception ex)
            {
                ViewBag.Modulo = new SelectList(_servicoModulo.ListarTodos(), "Id", "Nome", model.IdModulo);
                ViewBag.Professor = new SelectList(_servicoProfessor.ListarTodos(), "Id", "Nome", model.IdProfessor);
                ModelState.AddModelError("listaDeErros", ex.Message);
                return View(model);
            }

            CarregarModulo();
            CarregarProfessor();
        }

        #endregion

        #region Remover
        // GET: Turma/Delete/5
        public ActionResult Remover(Guid id)
        {
            var turma = _servicoTurma.BuscarPorId(id);
            return View(turma);
        }

        // POST: Turma/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remover(TurmaVM model)
        {
            try
            {
                var turma = _servicoTurma.BuscarPorId(model.Id);

                _servicoTurma.Remover(turma);

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

            if (turma.IdProfessor == Guid.Empty)
            {
                turma.IdProfessor = turma.Professor.Id;
            }

            return turma;
        }

        private TurmaVM CarregarDadosDaTurma(Guid id)
        {
            var turmaVM = _servicoTurma.BuscarPorId(id);

            if (turmaVM.IdProfessor == Guid.Empty)
            {
                turmaVM.IdProfessor = turmaVM.Professor.Id;
            }

            CarregarModulo();
            CarregarProfessor();

            return turmaVM;
        }

        private void CarregarModulo()
        {
            ViewBag.IdModulo = _servicoModulo.ListarTodos();
        }

        private void CarregarProfessor()
        {
            ViewBag.IdProfessor = _servicoProfessor.ListarTodos();
        }

        private void CarregarDadosDoProfessor(TurmaVM model)
        {
            if (model.Professor == null)
            {
                model.Professor = _servicoProfessor.BuscarPorId(model.IdProfessor);
            }
        }

        private void CarregarDadosDoModulo(TurmaVM model)
        {
            if (model.Modulo == null)
            {
                model.Modulo = _servicoModulo.BuscarPorId(model.IdModulo);
            }
        }

        private void MontarDadosDeTurma(TurmaVM model)
        {
            IList<AlunoVM> listaDeAlunos = new List<AlunoVM>();

            foreach (var item in model.Alunos)
            {
                var aluno = _servicoAluno.BuscarPorNome(item.Nome);

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
    }
}
