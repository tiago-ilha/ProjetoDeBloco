using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
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
    public class ProfessorRepositorio : IProfessorRepositorio
    {
        private ProjetoDeBlocoDataContext _contexto;

        public ProfessorRepositorio(ProjetoDeBlocoDataContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Professor> ObterPor()
        {
            return _contexto.Professores.ToList();
        }

        public Professor ObterPor(Guid id)
        {
            return _contexto.Professores.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool JaEstaSalvo(string nome)
        {
            var existe = _contexto.Professores.Where(x => x.Nome.ToLower() == nome.ToLower());

            if (existe.Count() > 0)
                return true;

            return false;
        }

        public void Salvar(Professor entidade)
        {
            _contexto.Professores.Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(Professor entidade)
        {
            _contexto.Entry<Professor>(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Remover(Professor entidade)
        {
            _contexto.Professores.Remove(entidade);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }        
    }
}
