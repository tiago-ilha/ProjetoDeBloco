using ProjetoDeBloco.Dominio.Entidades.AvaliacaoInstitucional;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using ProjetoDeBloco.Infraestrutura.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Infraestrutura.Repositorios
{
    public class AvaliacaoRepositorio : IAvaliacaoRepositorio
    {
        private ProjetoDeBlocoDataContext _contexto;

        public AvaliacaoRepositorio(ProjetoDeBlocoDataContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Avaliacao> ObterPor()
        {
            return _contexto.Avaliacao.ToList();
        }

        public Avaliacao ObterPor(Guid id)
        {
            return _contexto.Avaliacao.Where(x => x.Id == id).FirstOrDefault();            
        }

        public void Salvar(Avaliacao entidade)
        {
            foreach (Questao q in entidade.Questoes)
            {
                if (_contexto.Entry(q).State == EntityState.Detached)
                    _contexto.Questao.Attach(q);
            }

            _contexto.Avaliacao.Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(Avaliacao entidade)
        {
            _contexto.Entry<Avaliacao>(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Remover(Avaliacao entidade)
        {
            _contexto.Avaliacao.Remove(entidade);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public bool JaExiste(DateTime dataInicio)
        {
            return _contexto.Avaliacao.Any(x => x.dtInicio == dataInicio);
        }


        public IList<Avaliacao> ObterPorPeriodo(DateTime dataAtual)
        {
            return _contexto.Avaliacao.Where(x => x.dtInicio >= dataAtual || x.dtFim < dataAtual).ToList();
        }
    }
}
