using AutoMapper;
using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Estrutura;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.Servicos
{
    public class ModuloServico : IModuloServico
    {
        private readonly IModuloRepositorio _repModulo;

        public ModuloServico(IModuloRepositorio repModulo)
        {
            _repModulo = repModulo;
        }

        public IEnumerable<ModuloVM> ListarTodos()
        {
            var modulos = _repModulo.ObterPor();

            return Mapper.Map<IEnumerable<Modulo>, IEnumerable<ModuloVM>>(modulos);
        }

        public ModuloVM BuscarPorId(Guid id)
        {
            var modulo = _repModulo.ObterPor(id);
            return Mapper.Map<Modulo, ModuloVM>(modulo);
        }

        public void Cadastrar(ModuloVM entidade)
        {
            Modulo modulo;

            if (entidade.Id == Guid.Empty)
            {
                if (entidade.ProfessorTitular.Id != Guid.Empty)
                    modulo = new Modulo(entidade.Nome, entidade.Bloco.Id, entidade.ProfessorTitular.Id);

                else
                    modulo = new Modulo(entidade.Nome, entidade.Bloco.Id);

                _repModulo.Salvar(modulo);
            }
            else
            {
                modulo = _repModulo.ObterPor(entidade.Id);

                //if (modulo.ProfessorTitular.IdProfessor != Guid.Empty)                
                    modulo.Editar(entidade.Nome, entidade.IdBloco, entidade.IdProfessor);                
                //else
                

                

                _repModulo.Atualizar(modulo);


            }
        }

        public void Remover(ModuloVM entidade)
        {
            var modulo = _repModulo.ObterPor(entidade.Id);

            _repModulo.Remover(modulo);
        }

        public void Dispose()
        {
            _repModulo.Dispose();
        }
    }
}
