using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Dominio.Interfaces.Repositorios
{
    public interface IAdministradorRepositorio : IRepositorioBase<Administrador>
    {
        Administrador ObterUsuarioDoCoordenadorPorId(Guid id);
    }
}
