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
    public class BlocoServico : IBlocoServico
    {
        private IBlocoRepositorio _repBloco;
        private ICursoRepositorio _repCurso;

        public BlocoServico(IBlocoRepositorio repBloco, ICursoRepositorio repCurso)
        {
            _repBloco = repBloco;
            _repCurso = repCurso;
        }

        public IEnumerable<BlocoVM> ListarTodos()
        {
            var blocos = _repBloco.ObterPor();

            return Mapper.Map<IEnumerable<Bloco>, IEnumerable<BlocoVM>>(blocos);
        }

        public BlocoVM BuscarPorId(Guid id)
        {
            var bloco = _repBloco.ObterPor(id);

            return Mapper.Map<Bloco, BlocoVM>(bloco);
        }

        public void Cadastrar(BlocoVM entidade)
        {
            Bloco bloco;

            if (entidade.Id == Guid.Empty)
            {
                var curso = _repCurso.ObterPor(entidade.IdCurso);

                if (curso == null)
                    curso.Id = Guid.Empty;

                bloco = new Bloco(entidade.Nome, curso.Id);

                var jaExiste = _repBloco.JaExiste(entidade.Nome);

                if (jaExiste)
                    throw new Exception("Esse bloco cadastrado com esse nome!");

                _repBloco.Salvar(bloco);
            }
            else
            {
                bloco = _repBloco.ObterPor(entidade.Id);

                bloco.Editar(entidade.Nome, entidade.IdCurso);

                _repBloco.Atualizar(bloco);
            }
        }

        public void Remover(BlocoVM entidade)
        {
            var bloco = _repBloco.ObterPor(entidade.Id);

            _repBloco.Remover(bloco);
        }

        public void Dispose()
        {
            _repBloco.Dispose();
        }
    }
}
