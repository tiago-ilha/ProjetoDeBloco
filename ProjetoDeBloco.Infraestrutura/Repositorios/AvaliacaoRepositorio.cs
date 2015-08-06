using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using ProjetoDeBloco.Infraestrutura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Infraestrutura.Repositorios
{
    public class AvaliacaoRepositorio : IAvaliacaoRepositorio
    {
        private ProjetoDeBlocoDataContext _contexto;

        public AvaliacaoRepositorio(ProjetoDeBlocoDataContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Dominio.Entidades.AvaliacaoInstitucional.Avaliacao> ObterPor()
        {
            throw new NotImplementedException();
        }

        public Dominio.Entidades.AvaliacaoInstitucional.Avaliacao ObterPor(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Dominio.Entidades.AvaliacaoInstitucional.Avaliacao entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Dominio.Entidades.AvaliacaoInstitucional.Avaliacao entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(Dominio.Entidades.AvaliacaoInstitucional.Avaliacao entidade)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
