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
            //Turma turma;

            //if (entidade.Id == Guid.Empty)
            //{
            //    turma = new Turma(entidade.IdModulo);

                

            //    if(entidade.Alunos.Count > 0)
            //    {
                    
            //    }
            //}
            //throw new NotImplementedException();
        }

        public void Remover(ViewModels.TurmaVM entidade)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
