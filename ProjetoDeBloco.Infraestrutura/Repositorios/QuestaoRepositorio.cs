using ProjetoDeBloco.Dominio.Entidades.AvaliacaoInstitucional;
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
    public class QuestaoRepositorio : IQuestaoRepositorio
    {
        private ProjetoDeBlocoDataContext _contexto;


        public QuestaoRepositorio(ProjetoDeBlocoDataContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Dominio.Entidades.AvaliacaoInstitucional.Questao> ObterPor()
        {
            return _contexto.Questao.ToList();
        }

        public Dominio.Entidades.AvaliacaoInstitucional.Questao ObterPor(Guid id)
        {
            return _contexto.Questao.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Salvar(Dominio.Entidades.AvaliacaoInstitucional.Questao entidade)
        {
            _contexto.Questao.Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(Dominio.Entidades.AvaliacaoInstitucional.Questao entidade)
        {
            _contexto.Entry<Questao>(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Remover(Dominio.Entidades.AvaliacaoInstitucional.Questao entidade)
        {
            _contexto.Questao.Remove(entidade);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public bool JaExiste(string nome)
        {
            var jaExiste = _contexto.Questao.Where(x => x.PerguntaQuestao.ToLower() == nome.ToLower()).SingleOrDefault();

            if (jaExiste != null)
                return true;

            return false;
        }
    }
}
