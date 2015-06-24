using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<T> : IDisposable where T : class
    {
        IEnumerable<T> ObterPor();
        T ObterPor(Guid id);
        void Salvar(T entidade);
        void Atualizar(T entidade);
        void Remover(T entidade);

    }
}
