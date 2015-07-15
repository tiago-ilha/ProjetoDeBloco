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
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private ProjetoDeBlocoDataContext _contexto;

        public AlunoRepositorio(ProjetoDeBlocoDataContext contexto)
        {
            _contexto = contexto;
        }

        public Aluno ObterPor(string nome)
        {
            return _contexto.Alunos.Where(x => x.Nome.ToLower() == nome.ToLower()).FirstOrDefault();
        }

        public IEnumerable<Aluno> ObterPor()
        {
            return _contexto.Alunos.ToList();
        }

        public Aluno ObterPor(Guid id)
        {
            return _contexto.Alunos.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool JaEstaSalvo(string nome)
        {
            var existe = _contexto.Alunos.Where(x => x.Nome.ToLower() == nome.ToLower());

            if (existe.Count() > 0)
                return true;

            return false;
        }

        public void Salvar(Aluno entidade)
        {
            _contexto.Alunos.Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(Aluno entidade)
        {
            _contexto.Entry<Aluno>(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Remover(Aluno entidade)
        {
            _contexto.Alunos.Remove(entidade);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }        
    }
}
