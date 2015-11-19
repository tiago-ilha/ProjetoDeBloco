using AutoMapper;
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

        public UsuarioVM Logar(string login, string senha)
        {
            var usuario = _repositorio.Login(login, senha);

            return Mapper.Map<Usuario,UsuarioVM>(usuario);
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

			if (usuario.Id == Guid.Empty)
				_repositorio.Salvar(usuario);
			else
				_repositorio.Atualizar(usuario);
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
    }
}
