﻿using AutoMapper;
using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using ProjetoDeBloco.Dominio.Entidades.Administracao;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Aplicacao.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private IUsuarioRepositorio _repositorio;

        public UsuarioServico(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public bool Logar(string login, string senha)
        {
            return _repositorio.Login(login, senha);             
        }

        public bool JaExiste(string email)
        {
            return _repositorio.JaExiste(email);
        }

        public IEnumerable<UsuarioVM> ListarTodos()
        {
            var usuarios = _repositorio.ObterPor();

            return Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioVM>>(usuarios);
        }

        public UsuarioVM BuscarPorId(Guid id)
        {
            var usuario = _repositorio.ObterPor(id);

            return Mapper.Map<Usuario, UsuarioVM>(usuario);
        }

        public void Cadastrar(UsuarioVM entidade)
        {
            var usuario = Mapper.Map<UsuarioVM, Usuario>(entidade);

            Usuario usuarioBase;

            if (usuario.Id == Guid.Empty)   
            {
                usuarioBase = new Usuario(usuario.Email, usuario.Login, usuario.Senha);
                usuarioBase.AtivarUsuario();

                _repositorio.Salvar(usuarioBase);
            }
            else
            {
                usuarioBase = _repositorio.ObterPor(entidade.Id);

                if (entidade.Email != usuarioBase.Email)
                    usuarioBase.TrocarEmail(entidade.Email);

                if (entidade.Login != usuarioBase.Login)
                    usuarioBase.TrocarLogin(entidade.Login);

                if (entidade.Senha != usuarioBase.Senha)
                    usuarioBase.TrocarSenha(entidade.Senha);

                _repositorio.Atualizar(usuario);
            }                
        }

        public void Remover(UsuarioVM entidade)
        {
            var usuario = Mapper.Map<UsuarioVM, Usuario>(entidade);

            _repositorio.Remover(usuario);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }


        public UsuarioVM ObterUsuarioPeloLogin(string login)
        {
            var usuario = _repositorio.ObterUsuarioPorLogin(login);

            return Mapper.Map<Usuario, UsuarioVM>(usuario);
        }
    }
}
