using AutoMapper;
using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;

namespace ProjetoDeBloco.Aplicacao.Servicos
{
    public class TurmaServico : ITurmaServico
    {
        private ITurmaRepositorio _repTurma;

        public TurmaServico(ITurmaRepositorio repTurma)
        {
            _repTurma = repTurma;
        }

        public IEnumerable<TurmaVM> ListarTodos()
        {
            var turmas = _repTurma.ObterPor();

            return Mapper.Map<IEnumerable<Turma>, IEnumerable<TurmaVM>>(turmas);
        }

        public TurmaVM BuscarPorId(Guid id)
        {
            var turma = _repTurma.ObterPor(id);

            return Mapper.Map<Turma, TurmaVM>(turma);
        }

        public void Cadastrar(TurmaVM entidade)
        {
            Turma turma;

            if (entidade.Id == Guid.Empty)
            {                
                turma = new Turma(entidade.Identificador, entidade.Modulo.Id, entidade.IdProfessor);

                AdicionarAlunos(entidade, turma);

                _repTurma.Salvar(turma);
            }
            else
            {
                turma = _repTurma.ObterPor(entidade.Id);

                turma.Editar(entidade.Modulo.Id,entidade.Identificador,entidade.IdProfessor);

                AdicionarAlunos(entidade, turma);

                _repTurma.Salvar(turma);
            }
        }

        public void Remover(ViewModels.TurmaVM entidade)
        {
            var turma = _repTurma.ObterPor(entidade.Id);

            _repTurma.Remover(turma);
        }

        public void Dispose()
        {
            _repTurma.Dispose();
        }

        #region Método Compartilhado
        private void AdicionarAlunos(TurmaVM entidade, Turma turma)
        {

            if (entidade.Alunos.Count > 0)
            {
                var alunos = entidade.Alunos;
                foreach (var item in alunos)
                {
                    var alunoConvertido = Mapper.Map<AlunoVM, Aluno>(item);

                    turma.AdicionarAluno(alunoConvertido);

                    
                }
            }
        }

        #endregion
    }
}
