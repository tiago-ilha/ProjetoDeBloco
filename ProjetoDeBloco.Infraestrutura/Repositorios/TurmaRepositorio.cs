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
    public class TurmaRepositorio : ITurmaRepositorio
    {
        private ProjetoDeBlocoDataContext _contexto;

        public TurmaRepositorio(ProjetoDeBlocoDataContext contexto)
        {
            _contexto = contexto;
        }
        public IEnumerable<Turma> ObterPor()
        {
            return _contexto.Turmas.ToList();
        }

        public Turma ObterPor(Guid id)
        {
            return _contexto.Turmas.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Salvar(Turma entidade)
        {
            foreach (var item in entidade.Alunos)
            {
                _contexto.Alunos.Attach(item);
            }


            _contexto.Turmas.Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(Turma entidade)
        {
            _contexto.Entry<Turma>(entidade).State = EntityState.Modified;
        }

        public void Remover(Turma entidade)
        {
            _contexto.Turmas.Remove(entidade);
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
