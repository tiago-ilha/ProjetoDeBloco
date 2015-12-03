using AutoMapper;
using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using ProjetoDeBloco.Dominio.Entidades.Administracao;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using ProjetoDeBloco.Utilitarios.Seguranca;
using System;
using System.Collections.Generic;

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

                if (usuario != null && !_repUsuario.JaExiste(usuario.Email))
                {
                    _repUsuario.Salvar(usuario);
                }

                var idUsuario = _repUsuario.ObterUsuarioPorLogin(entidade.Usuario.Login).Id;

                var administrador = new Administrador(entidade.Nome, entidade.Usuario.Email, entidade.DataNascimento, idUsuario);

                _repAdministrador.Salvar(administrador);
            }
            else
            {
                var coordenador = _repAdministrador.ObterPor(entidade.Id);

                if (entidade.Usuario.Email != coordenador.Usuario.Email)
                    coordenador.Usuario.TrocarEmail(entidade.Usuario.Email);

                if (entidade.Usuario.Login != coordenador.Usuario.Login)
                    coordenador.Usuario.TrocarLogin(entidade.Usuario.Login);

                if (Criptografia.CriptografaSenha(entidade.Usuario.Senha) != coordenador.Usuario.Senha)
                    coordenador.Usuario.TrocarSenha(entidade.Usuario.Senha);

                _repUsuario.Atualizar(coordenador.Usuario);

                if (entidade.Nome != coordenador.Nome)
                    coordenador.TrocarNome(entidade.Nome);

                if (entidade.Email != coordenador.Email)
                    coordenador.TrocarEmail(entidade.Email);

                if (entidade.DataNascimento != coordenador.DataNascimento)
                    coordenador.TrocarDataDeNascimento(entidade.DataNascimento);

                _repAdministrador.Atualizar(coordenador);
            }
        }

        public void Remover(AdministradorVM entidade)
        {
            var administrador = Mapper.Map<AdministradorVM, Administrador>(entidade);

            _repUsuario.Remover(administrador.Usuario);

            _repAdministrador.Remover(administrador);
        }

        public void Dispose()
        {
            _repAdministrador.Dispose();
        }

        public AdministradorVM AtivarCoordenador(Guid id)
        {
            var administrador = _repAdministrador.ObterPor(id);

            return Mapper.Map<Administrador, AdministradorVM>(administrador);
        }
    }
}
