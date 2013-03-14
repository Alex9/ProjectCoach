using System;
using Raven.Client;

namespace Xemio.ProjectCoach.Core.ServiceManagement
{
    /// <summary>
    /// Is a session for service access.
    /// Handles creation of services and dynamic resolving.
    /// </summary>
    public class ServiceSession : IDisposable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceSession"/> class.
        /// </summary>
        /// <param name="serviceResolver">The service resolver.</param>
        internal ServiceSession(ServiceResolver serviceResolver)
        {
            this._serviceResolver = serviceResolver;
            this._serviceScope = serviceResolver.BeginScope();
        }
        #endregion Constructors

        #region Fields
        private readonly ServiceResolver _serviceResolver;
        private readonly IDisposable _serviceScope;
        #endregion Fields

        #region Methods
        /// <summary>
        /// Resolves the given service type.
        /// </summary>
        /// <typeparam name="T">The type of the service.</typeparam>
        public T GetService<T>()
        {
            return this._serviceResolver.Resolve<T>();
        }
        /// <summary>
        /// Saves all changes to the database.
        /// Works like a commit-method in a transaction.
        /// </summary>
        public void SaveChanges()
        {
            this.GetService<IDocumentSession>().SaveChanges();
        }
        #endregion Methods

        #region IDisposable Member
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this._serviceScope.Dispose();
        }
        #endregion IDisposable Member
    }
}
