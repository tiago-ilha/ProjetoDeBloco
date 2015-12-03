using ProjetoDeBloco.Dominio.Entidades.Administracao;
using ProjetoDeBloco.Dominio.Enum;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using ProjetoDeBloco.Infraestrutura.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeBloco.Infraestrutura.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private ProjetoDeBlocoDataContext _contexto;

        public UsuarioRepositorio(ProjetoDeBlocoDataContext contexto)
        {
            _contexto = contexto;
        }

        public Usuario ObterUsuarioPorLogin(string login)
        {
            return _contexto.Usuario.Where(x => x.Login.ToLower() == login.ToLower()).SingleOrDefault();
        }

        public bool JaExiste(string email)
        {
            return _contexto.Usuario.Any(x => x.Email.ToLower() == email.ToLower());
        }

        public bool Login(string login, string senha)
        {
            return _contexto.Usuario.Any(x => x.Login.ToLower().Trim() == login.ToLower().Trim() && x.Senha.Trim() == senha.Trim() && x.Situacao == SituacaoUsuario.Ativo);
        }

        public IEnumerable<Usuario> ObterPor()
        {
            return _contexto.Usuario.ToList();
        }

        public Usuario ObterPor(Guid id)
        {
            return _contexto.Usuario.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Salvar(Usuario entidade)
        {
            _contexto.Usuario.Add(entidade);
            _contexto.SaveChanges();
        }

        public void Atualizar(Usuario entidade)
        {
            _contexto.Entry<Usuario>(entidade).State = EntityState.Modified;
            _contexto.SaveChanges();
        }

        public void Remover(Usuario entidade)
        {
            _contexto.Usuario.Remove(entidade);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }       
    }
}
