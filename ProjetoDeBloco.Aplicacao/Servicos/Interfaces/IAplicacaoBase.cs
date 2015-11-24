using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.Servicos.Interfaces
{
    public interface IAplicacaoBase<T> : IDisposable where T : class
    {
        IEnumerable<T> ListarTodos();
        T BuscarPorId(Guid id);
        void Cadastrar(T entidade);
        void Remover(T entidade);

       
    }
}
