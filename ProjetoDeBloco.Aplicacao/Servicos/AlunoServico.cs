<<<<<<< HEAD
﻿using AutoMapper;
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

        public AlunoVM BuscarPorNome(string nome)
        {
            var aluno = _repAluno.ObterPor(nome);

            return Mapper.Map<Aluno, AlunoVM>(aluno);
        }

        public void Cadastrar(AlunoVM entidade)
        {
            Aluno aluno;

            if (entidade.Id == Guid.Empty)
            {
                aluno = new Aluno(entidade.Nome, entidade.DataNascimento);
                aluno.Ativar();

                GerarMatricula(aluno);

                VerificaSeJaExiste(entidade);

                _repAluno.Salvar(aluno);
            }
            else
            {
                aluno = _repAluno.ObterPor(entidade.Id);

                aluno.Editar(entidade.Nome, entidade.DataNascimento);
                if (!aluno.Ativo)
                    aluno.Ativar();

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

        private void VerificaSeJaExiste(AlunoVM entidade)
        {
            var jaExiste = _repAluno.JaEstaSalvo(entidade.Nome);

            if (jaExiste)
                throw new Exception("Já existe um professor cadastrado com esse nome!");
        }

        private void GerarMatricula(Aluno aluno)
        {
            var listaDePessoas = _repAluno.ObterPor();

            long matricula = 0;
            if (listaDePessoas.Count() > 0)
            {
                matricula = listaDePessoas.OrderBy(x => x.Matricula).Reverse().FirstOrDefault().Matricula;
                ServicoGeradorDeMatricula.Gerar(aluno, matricula);
            }
            else
                ServicoGeradorDeMatricula.Gerar(aluno, matricula);
        }

        #endregion       
    }
}
=======
﻿using AutoMapper;
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

        public AlunoVM BuscarPorNome(string nome)
        {
            var aluno = _repAluno.ObterPor(nome);

            return Mapper.Map<Aluno, AlunoVM>(aluno);
        }

        public void Cadastrar(AlunoVM entidade)
        {
            Aluno aluno;

            if (entidade.Id == Guid.Empty)
            {
                aluno = new Aluno(entidade.Nome, entidade.DataNascimento,entidade.Email);
                aluno.Ativar();

                GerarMatricula(aluno);

                VerificaSeJaExiste(entidade);

                _repAluno.Salvar(aluno);
            }
            else
            {
                aluno = _repAluno.ObterPor(entidade.Id);

                aluno.Editar(entidade.Nome, entidade.DataNascimento,entidade.Email);
                if (!aluno.Ativo)
                    aluno.Ativar();

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

        private void VerificaSeJaExiste(AlunoVM entidade)
        {
            var jaExiste = _repAluno.JaEstaSalvo(entidade.Nome);

            if (jaExiste)
                throw new Exception("Já existe um professor cadastrado com esse nome!");
        }

        private void GerarMatricula(Aluno aluno)
        {
            var listaDePessoas = _repAluno.ObterPor();

            long matricula = 0;
            if (listaDePessoas.Count() > 0)
            {
                matricula = listaDePessoas.OrderBy(x => x.Matricula).Reverse().FirstOrDefault().Matricula;
                ServicoGeradorDeMatricula.Gerar(aluno, matricula);
            }
            else
                ServicoGeradorDeMatricula.Gerar(aluno, matricula);
        }

        #endregion       
    }
}
>>>>>>> 783aa6575c0558e368e19a68b44aeb2233109a24
