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
    public class BlocoRepositorio : IBlocoRepositorio
    {
        private ProjetoDeBlocoDataContext _contexto;

        public BlocoRepositorio(ProjetoDeBlocoDataContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Bloco> ObterBlocosDoCurso(Guid idCurso)
        {
            return _contexto.Blocos.Where(x => x.IdCurso == idCurso).ToList();
        }

        public IEnumerable<Bloco> ObterPor()
        {
            return _contexto.Blocos.ToList();
        }

        public Bloco ObterPor(Guid id)
        {
            return _contexto.Blocos.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool JaExiste(string nome)
        {
            var bloco = _contexto.Blocos.Where(x => x.Nome.ToLower() == nome.ToLower()).SingleOrDefault();

            if (bloco != null)
                return true;

            return false;
        }

        public void Salvar(Bloco entidade)
        {
            _contexto.Blocos.Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(Bloco entidade)
        {
            _contexto.Entry<Bloco>(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Remover(Bloco entidade)
        {
            _contexto.Blocos.Remove(entidade);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }       
    }
}
