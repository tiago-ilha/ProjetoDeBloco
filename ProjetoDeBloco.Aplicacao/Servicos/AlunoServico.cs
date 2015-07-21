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
    public class AlunoServico : IAlunoServico
    {
        private readonly IAlunoRepositorio _repAluno;

        public AlunoServico(IAlunoRepositorio repAluno)
        {
            _repAluno = repAluno;
        }

        public IEnumerable<AlunoVM> ListarTodos()
        {
            var alunos = _repAluno.ObterPor();

            return Mapper.Map<IEnumerable<Aluno>, IEnumerable<AlunoVM>>(alunos);
        }

        public AlunoVM BuscarPorId(Guid id)
        {
            var aluno = _repAluno.ObterPor(id);

            return Mapper.Map<Aluno, AlunoVM>(aluno);
        }

        public void Cadastrar(AlunoVM entidade)
        {
            Aluno aluno;

            if (entidade.Id == Guid.Empty)
            {
                aluno = new Aluno(entidade.Nome, entidade.DataNascimento);

                if (!JaExsiteCadastrado(aluno))
                {
                    //ServicoGeradorDeMatricula.Gerar(aluno);
                    _repAluno.Salvar(aluno);
                }
            }
            else
            {
                aluno = _repAluno.ObterPor(entidade.Id);

                aluno.Editar(entidade.Nome, entidade.DataNascimento);

                _repAluno.Atualizar(aluno);
            }
        }        

        public void Remover(AlunoVM entidade)
        {
            var aluno = _repAluno.ObterPor(entidade.Id);

            _repAluno.Remover(aluno);
        }

        public void Dispose()
        {
            _repAluno.Dispose();
        }

        #region "Métodos compartilhados"

        private bool JaExsiteCadastrado(Aluno aluno)
        {
            var jaExiste = _repAluno.JaEstaSalvo(aluno.Nome);

            if (jaExiste)
            {
                throw new Exception("Aluno já foi cadastrado com esse nome!");
                return true;
            }

            return false;
        }

        #endregion
    }
}
