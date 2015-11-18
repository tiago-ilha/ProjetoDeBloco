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
    public class RecursoFilhoRepositorio : IRecursoFilhoRepositorio
    {
        private ProjetoDeBlocoDataContext _contexto;

        public RecursoFilhoRepositorio(ProjetoDeBlocoDataContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<RecursoFilho> ObterPor()
        {
            return _contexto.RecursoFilho.ToList(); 
        }

        public RecursoFilho ObterPor(Guid id)
        {
            return _contexto.RecursoFilho.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Salvar(RecursoFilho entidade)
        {
            _contexto.RecursoFilho.Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(RecursoFilho entidade)
        {
            _contexto.Entry<RecursoFilho>(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Remover(RecursoFilho entidade)
        {
            _contexto.RecursoFilho.Remove(entidade);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
