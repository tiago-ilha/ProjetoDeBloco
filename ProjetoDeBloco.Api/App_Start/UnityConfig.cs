using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using ProjetoDeBloco.Dominio.Interfaces.Repositorios;
using ProjetoDeBloco.Infraestrutura.Repositorios;
using ProjetoDeBloco.Aplicacao.Servicos.Interfaces;
using ProjetoDeBloco.Aplicacao.Servicos;

namespace ProjetoDeBloco.Api.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<ICursoRepositorio, CursoRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IBlocoRepositorio, BlocoRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IModuloRepositorio, ModuloRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IProfessorRepositorio, ProfessorRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IAlunoRepositorio, AlunoRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<ITurmaRepositorio, TurmaRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IAvaliacaoRepositorio, AvaliacaoRepositorio>(new HierarchicalLifetimeManager());
            container.RegisterType<IQuestaoRepositorio, QuestaoRepositorio>(new HierarchicalLifetimeManager());

            container.RegisterType<ICursoServico, CursoServico>(new HierarchicalLifetimeManager());
            container.RegisterType<IBlocoServico, BlocoServico>(new HierarchicalLifetimeManager());
            container.RegisterType<IModuloServico, ModuloServico>(new HierarchicalLifetimeManager());
            container.RegisterType<IProfessorServico, ProfessorServico>(new HierarchicalLifetimeManager());
            container.RegisterType<IAlunoServico, AlunoServico>(new HierarchicalLifetimeManager());
            container.RegisterType<ITurmaServico, TurmaServico>(new HierarchicalLifetimeManager());
            container.RegisterType<IAvaliacaoServico, AvaliacaoServico>(new HierarchicalLifetimeManager());
            container.RegisterType<IQuestaoServico, QuestaoServico>(new HierarchicalLifetimeManager());
        }
    }
}
