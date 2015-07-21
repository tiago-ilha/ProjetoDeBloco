using AutoMapper;
using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using ProjetoDeBloco.Dominio.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.Servicos
{
    public class ProfessorServico : IProfessorServico
    {
        private readonly IProfessorRepositorio _repProfessor;       

        public ProfessorServico(IProfessorRepositorio repProfessor)
        {
            _repProfessor = repProfessor;
        }

        public IEnumerable<ProfessorVM> ListarTodos()
        {
            var professores = _repProfessor.ObterPor();

            return Mapper.Map<IEnumerable<Professor>, IEnumerable<ProfessorVM>>(professores);
        }

        public ViewModels.ProfessorVM BuscarPorId(Guid id)
        {
            var professor = _repProfessor.ObterPor(id);

            return Mapper.Map<Professor, ProfessorVM>(professor);
        }

        public void Cadastrar(ViewModels.ProfessorVM entidade)
        {
            Professor professor;

            if (entidade.Id == Guid.Empty)
            {
                professor = new Professor(entidade.Nome, entidade.DataNascimento, entidade.AreaDeFormacao, entidade.AnoDeFormacao);
                professor.Ativar();

                GerarMatricula(professor);

                VerificaSeJaExiste(entidade);

                _repProfessor.Salvar(professor);
            }
            else
            {
                professor = _repProfessor.ObterPor(entidade.Id);

                professor.Editar(entidade.Nome, entidade.DataNascimento, entidade.AreaDeFormacao, entidade.AnoDeFormacao);

                professor.Ativar();

                _repProfessor.Atualizar(professor);
            }
        }        

        public void Remover(ViewModels.ProfessorVM entidade)
        {
            var professor = _repProfessor.ObterPor(entidade.Id);

            _repProfessor.Remover(professor);
        }

        public void Dispose()
        {
            _repProfessor.Dispose();
        }

        #region Métodos Compartilhados

        private void VerificaSeJaExiste(ViewModels.ProfessorVM entidade)
        {
            var jaExiste = _repProfessor.JaEstaSalvo(entidade.Nome);

            if (jaExiste)
                throw new Exception("Já existe um professor cadastrado com esse nome!");
        }

        private void GerarMatricula(Professor professor)
        {
            var listaDePessoas = _repProfessor.ObterPor();

            long matricula = 0;
            if (listaDePessoas.Count() > 0)
            {
                matricula = listaDePessoas.OrderBy(x => x.Matricula).Reverse().FirstOrDefault().Matricula;
                ServicoGeradorDeMatricula.Gerar(professor, matricula);
            }
            else
                ServicoGeradorDeMatricula.Gerar(professor, matricula);
        }       

        #endregion
    }
}
