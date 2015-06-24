using ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura;
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
    public class ModuloRepositorio : IModuloRepositorio
    {
        private ProjetoDeBlocoDataContext _contexto;

        public ModuloRepositorio(ProjetoDeBlocoDataContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Modulo> ObterPor()
        {
            return _contexto.Modulos.ToList();
        }

        public Modulo ObterPor(Guid id)
        {
            return _contexto.Modulos.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Salvar(Modulo entidade)
        {
            _contexto.Modulos.Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(Modulo entidade)
        {
            _contexto.Entry<Modulo>(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Remover(Modulo entidade)
        {
            _contexto.Modulos.Remove(entidade);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
