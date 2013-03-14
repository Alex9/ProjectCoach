using System.Reflection;
using CuttingEdge.Conditions;
using Raven.Client;
using Raven.Client.Indexes;

namespace Xemio.ProjectCoach.Core.ServiceManagement
{
    /// <summary>
    /// Handles session creation.
    /// </summary>
    public class ServiceManager
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceManager"/> class.
        /// </summary>
        /// <param name="documentStore">The document store.</param>
        /// <param name="assemblies">The assemblies.</param>
        public ServiceManager(IDocumentStore documentStore, params Assembly[] assemblies)
        {
            Condition.Requires(documentStore)
                .IsNotNull();

            this._serviceResolver = new ServiceResolver(documentStore, assemblies);

            this.InitializeDocumentStore(documentStore);
        }
        #endregion Constructors

        #region Fields
        private readonly ServiceResolver _serviceResolver;
        #endregion Fields

        #region Methods
        /// <summary>
        /// Opens a new service session.
        /// </summary>
        public ServiceSession OpenSession()
        {
            return new ServiceSession(this._serviceResolver);
        }
        #endregion Methods

        #region Private Methods
        /// <summary>
        /// Initializes the document store and creates indexes.
        /// </summary>
        /// <param name="documentStore">The document store.</param>
        private void InitializeDocumentStore(IDocumentStore documentStore)
        {
            documentStore.Initialize();
            IndexCreation.CreateIndexes(this.GetType().Assembly, documentStore);
        }
        #endregion Private Methods
    }
}
