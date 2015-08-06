using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.Servicos
{
    public class AvaliacaoServico : IAvaliacaoServico  
    { 
        public IEnumerable<AvaliacaoVM> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public AvaliacaoVM BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(AvaliacaoVM entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(AvaliacaoVM entidade)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
