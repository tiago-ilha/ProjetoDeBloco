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
    public class AutorizacaoRepositorio : IAutorizacaoRepositorio
    {
         private ProjetoDeBlocoDataContext _contexto;

         public AutorizacaoRepositorio(ProjetoDeBlocoDataContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Autorizacao> ObterPor()
        {
            return _contexto.Autorizacao.ToList();
        }

        public Autorizacao ObterPor(Guid id)
        {
            return _contexto.Autorizacao.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Salvar(Autorizacao entidade)
        {
            _contexto.Autorizacao.Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(Autorizacao entidade)
        {
            _contexto.Entry<Autorizacao>(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Remover(Autorizacao entidade)
        {
            _contexto.Autorizacao.Remove(entidade);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
