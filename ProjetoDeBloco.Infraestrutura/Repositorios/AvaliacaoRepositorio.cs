using ProjetoDeBloco.Dominio.Entidades.AvaliacaoInstitucional;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using ProjetoDeBloco.Infraestrutura.Data;
using System;
using System.Collections.Generic;
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
            _contexto.Avaliacao.Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(Avaliacao entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(Avaliacao entidade)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
