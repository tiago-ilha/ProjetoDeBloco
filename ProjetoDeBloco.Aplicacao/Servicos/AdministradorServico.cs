using AutoMapper;
using ProjetoDeBloco.Aplicacao.Excecoes;
using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.ViewModels;
using ProjetoDeBloco.Dominio.Entidades.Administracao;
using ProjetoDeBloco.Dominio.Entidades.Instituicao.Pessoas;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
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
			try
			{
				if (entidade.Id == Guid.Empty)
				{
					var usuario = new Usuario(entidade.Usuario.Email, entidade.Usuario.Login, entidade.Usuario.Senha);

					if (usuario != null && !_repUsuario.JaExiste(usuario.Email))
					{
						_repUsuario.Salvar(usuario);
					}

					var idUsuario = _repUsuario.ObterUsuarioPorLogin(entidade.Usuario.Login).Id;

					var administrador = new Administrador(entidade.Nome, entidade.Usuario.Email, DateTime.Now, idUsuario);

					_repAdministrador.Salvar(administrador);
				}
				else
				{
					var administrador = _repAdministrador.ObterPor(entidade.Id);

					if (entidade.Nome != administrador.Nome)
						administrador.TrocarNome(entidade.Nome);

					if (entidade.Email != administrador.Email)
						administrador.TrocarEmail(entidade.Email);

					if (entidade.DataNascimento != administrador.DataNascimento)
						administrador.TrocarDataDeNascimento(entidade.DataNascimento);

					if (entidade.Usuario.Login != administrador.Usuario.Login)
						administrador.Usuario.TrocarLogin(entidade.Usuario.Login);

					if (entidade.Usuario.Senha != administrador.Usuario.Senha)
						administrador.Usuario.TrocarSenha(entidade.Usuario.Senha);

					_repAdministrador.Atualizar(administrador);
				}
			}
			catch
			{
				throw new UsuarioJaCadastradoExcecao();
			}
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
