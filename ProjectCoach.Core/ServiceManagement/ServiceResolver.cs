using System;
using System.Reflection;
using CuttingEdge.Conditions;
using Ninject;
using Raven.Client;
using Xemio.ProjectCoach.Core.Services;

namespace Xemio.ProjectCoach.Core.ServiceManagement
{
    /// <summary>
    /// Components are registered and later resolved.
    /// Works as an Inversion-Of-Control Container.
    /// </summary>
    internal class ServiceResolver
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceResolver" /> class.
        /// </summary>
        /// <param name="documentStore">The document store.</param>
        /// <param name="moduleAssemblies">The assemblies that contains NinjectModules.</param>
        public ServiceResolver(IDocumentStore documentStore, params Assembly[] moduleAssemblies)
        {
            Condition.Requires(documentStore)
                .IsNotNull();

            this._ninjectContainer.Load(new ServiceModule(documentStore));
            this._ninjectContainer.Load(moduleAssemblies);
        }
        #endregion Constructors

        #region Fields
        private readonly IKernel _ninjectContainer = new StandardKernel();
        #endregion Fields

        #region Methods
        /// <summary>
        /// Begins the scope.
        /// </summary>
        public IDisposable BeginScope()
        {
            return this._ninjectContainer.BeginBlock();
        }
        /// <summary>
        /// Resolves the given service type.
        /// </summary>
        /// <typeparam name="T">The service type.</typeparam>
        public T Resolve<T>() where T : IService
        {
            return this._ninjectContainer.Get<T>();
        }
        #endregion Methods
    }
}
