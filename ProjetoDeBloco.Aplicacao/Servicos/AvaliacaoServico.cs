using AutoMapper;
using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using ProjetoDeBloco.Dominio.Entidades.AvaliacaoInstitucional;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.Servicos
{
    public class AvaliacaoServico : IAvaliacaoServico  
    {
        private IAvaliacaoRepositorio _repAvaliacao;
        private ITurmaRepositorio _repTurma;

        public AvaliacaoServico(IAvaliacaoRepositorio repAvaliacao, ITurmaRepositorio repTurma)
        {
            _repAvaliacao = repAvaliacao;
            _repTurma = repTurma;
        }

        public IEnumerable<AvaliacaoVM> ListarTodos()
        {

            var Avaliacoes = _repAvaliacao.ObterPor();

            return Mapper.Map<IEnumerable<Avaliacao>, IEnumerable<AvaliacaoVM>>(Avaliacoes);
        }

        public AvaliacaoVM BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(AvaliacaoVM entidade)
        {
            Avaliacao avaliacao;

            if (entidade.Id == Guid.Empty)
            {
                var turma = _repTurma.ObterPor(entidade.turma.Id);




                if (turma == null)
                    turma.Id= Guid.Empty;

                avaliacao = new Avaliacao() 
                {
                    dtFim = entidade.dtFim,
                    dtInicio = entidade.dtInicio,
                    Id = entidade.Id,
                    objAvaliacao = entidade.objAvaliacao,
                    IdTurma = entidade.turma.Id                    
                };
                    


              //  var jaExiste = _repAvaliacao.JaExiste(entidade.dtInicio);

               // if (jaExiste)
                 //   throw new Exception("Esse bloco cadastrado com esse nome!");

                _repAvaliacao.Salvar(avaliacao);












                //Turma turma;

                //if (entidade.Id == Guid.Empty)
                //{
                //    turma = new Turma(entidade.Identificador, entidade.Modulo.Id, entidade.IdProfessor);

                //    AdicionarAlunos(entidade, turma);

                //    _repTurma.Salvar(turma);
                //}
                //else
                //{
                //    turma = _repTurma.ObterPor(entidade.Id);

                //    turma.Editar(entidade.Modulo.Id, entidade.Identificador, entidade.IdProfessor);

                //    AdicionarAlunos(entidade, turma);

                //    _repTurma.Salvar(turma);
                //}
            }
            else
            {
                avaliacao = _repAvaliacao.ObterPor(entidade.Id);

             //   bloco.Editar(entidade.Nome, entidade.IdCurso);

               // _repBloco.Atualizar(bloco);
            }
        }

        public void Remover(AvaliacaoVM entidade)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _repAvaliacao.Dispose();
        }
    }
}
