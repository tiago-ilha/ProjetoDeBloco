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
    public class PerfilRepositorio : IPerfilRepositorio
    {
        private ProjetoDeBlocoDataContext _contexto;

        public PerfilRepositorio(ProjetoDeBlocoDataContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Perfil> ObterPor()
        {
            return _contexto.Perfil.ToList();
        }

        public Perfil ObterPor(Guid id)
        {
            return _contexto.Perfil.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Salvar(Perfil entidade)
        {
            _contexto.Perfil.Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(Perfil entidade)
        {
            _contexto.Entry<Perfil>(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Remover(Perfil entidade)
        {
            _contexto.Perfil.Remove(entidade);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
