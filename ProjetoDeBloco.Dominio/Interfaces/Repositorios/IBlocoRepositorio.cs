using ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Interfaces.Repositorios
{
    public interface IBlocoRepositorio : IRepositorioBase<Bloco>
    {
        IEnumerable<Bloco> ObterBlocosDoCurso(Guid IdCurso);

        bool JaExiste(string nome);
    }
}
