using ProjetoDeBloco.Dominio.Entidades.AvaliacaoInstitucional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Interfaces.Repositorios
{
    public interface IQuestaoRepositorio : IRepositorioBase<Questao>
    {
        bool JaExiste(string nome);

       // T ObterPorPergunta(string pergunta);

         Questao ObterPorPergunta(String pergunta);
    }
}
