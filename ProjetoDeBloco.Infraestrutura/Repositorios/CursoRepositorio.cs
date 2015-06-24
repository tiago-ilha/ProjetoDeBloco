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
    public class CursoRepositorio : ICursoRepositorio
    {
        private ProjetoDeBlocoDataContext _contexto;

        public CursoRepositorio(ProjetoDeBlocoDataContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Curso> ObterPor()
        {
            return _contexto.Cursos.ToList();
        }

        public Curso ObterPor(Guid id)
        {
            return _contexto.Cursos.Where(x => x.Id == id).FirstOrDefault();
        }

        public Curso ObterPorNome(string nome)
        {
            return _contexto.Cursos.Where(x => x.Nome.ToLower() == nome.ToLower()).FirstOrDefault();
        }

        public void Salvar(Curso entidade)
        {
            _contexto.Cursos.Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(Curso entidade)
        {
            _contexto.Entry<Curso>(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Remover(Curso entidade)
        {
            _contexto.Cursos.Remove(entidade);
            _contexto.SaveChanges();
        }

        public bool JaExiste(string nome)
        {
            var jaExiste = _contexto.Cursos.Where(x => x.Nome.ToLower() == nome.ToLower()).SingleOrDefault();

            if (jaExiste != null)            
                return true;

            return false;            
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }       
    }
}
