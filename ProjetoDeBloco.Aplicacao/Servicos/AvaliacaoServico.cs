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
            throw new NotImplementedException();
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
