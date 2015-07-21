using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using ProjetoDeBloco.Infraestrutura.Repositorios;
using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.Servicos;

namespace ProjetoDeBloco.IoC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ICursoRepositorio, CursoRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IBlocoRepositorio, BlocoRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IModuloRepositorio, ModuloRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IProfessorRepositorio, ProfessorRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IAlunoRepositorio, AlunoRepositorio>(new HierarchicalLifetimeManager());
            

            container.RegisterType<ICursoServico, CursoServico>(new HierarchicalLifetimeManager());
            container.RegisterType<IBlocoServico, BlocoServico>(new HierarchicalLifetimeManager());
            container.RegisterType<IModuloServico, ModuloServico>(new HierarchicalLifetimeManager());
            container.RegisterType<IProfessorServico, ProfessorServico>(new HierarchicalLifetimeManager());
            container.RegisterType<IAlunoServico, AlunoServico>(new HierarchicalLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}