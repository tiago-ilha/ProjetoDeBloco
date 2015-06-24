    using AutoMapper;
using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.Servicos
{
    public class CursoServico : ICursoServico
    {
        private ICursoRepositorio _repCurso;

        public CursoServico(ICursoRepositorio repCurso)
        {
            _repCurso = repCurso;
        }

        public IEnumerable<CursoVM> ListarTodos()
        {
            var cursos = _repCurso.ObterPor();

            return Mapper.Map<IEnumerable<Curso>, IEnumerable<CursoVM>>(cursos);
        }

        public CursoVM BuscarPorNome(string nome)
        {
            var curso = _repCurso.ObterPorNome(nome);

            return Mapper.Map<Curso, CursoVM>(curso);
        }

        public CursoVM BuscarPorId(Guid id)
        {
            var curso = _repCurso.ObterPor(id);

            return Mapper.Map<Curso, CursoVM>(curso);
        }

        public void Cadastrar(CursoVM entidade)
        {
            Curso curso;

            if (entidade.Id == Guid.Empty)
            {
                curso = new Curso(entidade.Codigo , entidade.Nome);

                var jaExisteCurso = _repCurso.JaExiste(entidade.Nome);

                if (jaExisteCurso)
                    throw new Exception("Esse curso cadastrado com esse nome!");

                _repCurso.Salvar(curso);                
            }
            else
            {
                curso = _repCurso.ObterPor(entidade.Id);

                curso.Editar(entidade.Codigo, entidade.Nome);

                _repCurso.Atualizar(curso);
            }
        }

        public void Remover(ViewModels.CursoVM entidade)
        {
            var curso = _repCurso.ObterPor(entidade.Id);

            _repCurso.Remover(curso);
        }

        public void Dispose()
        {
            _repCurso.Dispose();
        }
    }
}
