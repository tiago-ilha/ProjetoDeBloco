using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using ProjetoDeBloco.Infraestrutura.Data;
using System.Data.Entity;

namespace ProjetoDeBloco.Infraestrutura.Repositorios
{
    public class AdministradorRepositorio : IAdministradorRepositorio
    {
        private ProjetoDeBlocoDataContext _contexto;

        public AdministradorRepositorio(ProjetoDeBlocoDataContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Administrador> ObterPor()
        {
            return _contexto.Administradores.ToList();
        }

        public Administrador ObterPor(Guid id)
        {
            return _contexto.Administradores.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Salvar(Administrador entidade)
        {
            _contexto.Administradores.Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(Administrador entidade)
        {
            _contexto.Entry<Administrador>(entidade).State = EntityState.Modified;
        }

        public void Remover(Administrador entidade)
        {
            _contexto.Administradores.Remove(entidade);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
