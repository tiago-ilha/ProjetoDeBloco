using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoDeBloco.Aplicacao.ViewModels;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using AutoMapper;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using ProjetoDeBloco.Dominio.Entidades.Administracao;

namespace ProjetoDeBloco.Aplicacao.Servicos
{
    public class AdministradorServico : IAdministradorServico
    {
        private readonly IAdministradorRepositorio _repAdministrador;
        private readonly IUsuarioRepositorio _repUsuario;

        public AdministradorServico(IAdministradorRepositorio repAdministrador, IUsuarioRepositorio repUsuario)
        {
            _repAdministrador = repAdministrador;
            _repUsuario = repUsuario;
        }

        public IEnumerable<AdministradorVM> ListarTodos()
        {
            var administradores = _repAdministrador.ObterPor();

            return Mapper.Map<IEnumerable<Administrador>, IEnumerable<AdministradorVM>>(administradores);

            //var alunos = _repAluno.ObterPor();

            //return Mapper.Map<IEnumerable<Aluno>, IEnumerable<AlunoVM>>(alunos);
        }

        public AdministradorVM BuscarPorId(Guid id)
        {
            return Mapper.Map<Administrador, AdministradorVM>(_repAdministrador.ObterPor(id));
        }

        public void Cadastrar(AdministradorVM entidade)
        {
            if (entidade.Id == Guid.Empty)
            {                
                var usuario = new Usuario(entidade.Usuario.Email, entidade.Usuario.Login, entidade.Usuario.Senha);

                _repUsuario.Salvar(usuario);

                var idUsuario = _repUsuario.ObterUsuarioPorLogin(entidade.Usuario.Login).Id;

                var administrador = new Administrador(entidade.Nome, entidade.Usuario.Email, DateTime.Now, idUsuario);

                _repAdministrador.Salvar(administrador);
            }
            //else
            //{
            //    var administrador = _repAdministrador.ObterPor(entidade.Id);
            //    var usuario = _repUsuario.ObterPor(administrador.IdUsuario);
            //    administrador.IdUsuario = usuario.Id;

            //    if (administrador.Nome != entidade.Nome)
            //        administrador.TrocarNome(entidade.Nome);

            //    if (administrador.Email != entidade.Email)
            //        administrador.TrocarEmail(entidade.Email);

            //    if (administrador.DataNascimento != entidade.DataNascimento)
            //        administrador.TrocarDataDeNascimento(entidade.DataNascimento);



            //}
        }

        public void Remover(AdministradorVM entidade)
        {
            var administrador = Mapper.Map<AdministradorVM, Administrador>(entidade);

            _repAdministrador.Remover(administrador);
        }

        public void Dispose()
        {
            _repAdministrador.Dispose();
        }
    }
}
