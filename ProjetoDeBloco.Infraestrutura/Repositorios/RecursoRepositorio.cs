using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDeBloco.Dominio.Entidades.Administracao;
using ProjetoDeBloco.Infraestrutura.Data;
using System.Data.Entity;

namespace ProjetoDeBloco.Infraestrutura.Repositorios
{
    public class RecursoRepositorio : IRecursoRepositorio
    {
        private ProjetoDeBlocoDataContext _contexo;

        public RecursoRepositorio(ProjetoDeBlocoDataContext contexto)
        {
            _contexo = contexto;
        }

        public IEnumerable<Recurso> ObterPor()
        {
            return _contexo.Recurso.ToList();
        }

        public Recurso ObterPor(Guid id)
        {
            return _contexo.Recurso.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Salvar(Recurso entidade)
        {
            _contexo.Recurso.Add(entidade);
            _contexo.SaveChanges();
        }

        public void Atualizar(Recurso entidade)
        {
            _contexo.Entry<Recurso>(entidade).State = EntityState.Modified;
            _contexo.SaveChanges();
        }

        public void Remover(Recurso entidade)
        {
            _contexo.Recurso.Remove(entidade);
            _contexo.SaveChanges();
        }

        public void Dispose()
        {
            _contexo.Dispose();
        }
    }
}
