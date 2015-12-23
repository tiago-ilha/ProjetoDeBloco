using ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura;
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
    public class TurmaRepositorio : ITurmaRepositorio
    {
        private ProjetoDeBlocoDataContext _contexto;

        public TurmaRepositorio(ProjetoDeBlocoDataContext contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Turma> ObterPor()
        {
            return _contexto.Turmas.Include(x => x.Professor).ToList();
        }

        public Turma ObterPor(Guid id)
        {
            return _contexto.Turmas.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Salvar(Turma entidade)
        {
            foreach (Aluno a in entidade.Alunos)
            {
                if (_contexto.Entry(a).State == EntityState.Detached)
                    _contexto.Alunos.Attach(a);
            }


            _contexto.Turmas.Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(Turma entidade)
        {
            foreach (var item in entidade.Alunos)
            {
                _contexto.Alunos.Attach(item);
            }

            _contexto.Entry<Turma>(entidade).State = EntityState.Added;
            _contexto.SaveChanges();
        }

        public void Remover(Turma entidade)
        {
            foreach (var item in entidade.Alunos)
            {
                _contexto.Alunos.Attach(item);
            }

            _contexto.Turmas.Remove(entidade);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
