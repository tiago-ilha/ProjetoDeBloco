using ProjetoDeBloco.Dominio.Entidades;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Interfaces.Repositorios
{
    public interface ICursoRepositorio : IRepositorioBase<Curso>
    {
        Curso ObterPorNome(string nome);

        bool JaExiste(string nome);
    }
}
