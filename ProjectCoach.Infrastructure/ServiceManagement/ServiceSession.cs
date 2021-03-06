﻿using Ninject;
using Ninject.Activation.Blocks;
using Raven.Client;
using Xemio.ProjectCoach.Core.ServiceManagement;

namespace Xemio.ProjectCoach.Infrastructure.ServiceManagement
{
    /// <summary>
    /// Is a documentSession for service access.
    /// Handles creation of services and dynamic resolving.
    /// </summary>
    internal class ServiceSession : IServiceSession
    {
        #region Fields
        private readonly IActivationBlock _activationBlock;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceSession"/> class.
        /// </summary>
        /// <param name="ninjectKernel">The ninject-kernel used for dependency injection.</param>
        internal ServiceSession(IKernel ninjectKernel)
        {
            this._activationBlock = ninjectKernel.BeginBlock();
        }
        #endregion Constructors

        #region IDisposable Member
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this._activationBlock.Dispose();
        }
        #endregion IDisposable Member

        #region IServiceSession Members
        /// <summary>
        /// Resolves the given service type.
        /// </summary>
        /// <typeparam name="T">The type of the service.</typeparam>
        public T GetService<T>()
        {
            return this._activationBlock.Get<T>();
        }
        /// <summary>
        /// Gets the given service.
        /// Returns the type because of it's name.
        /// </summary>
        /// <typeparam name="T">The type of the service.</typeparam>
        /// <param name="name">The name.</param>
        public T GetService<T>(string name)
        {
            return this._activationBlock.Get<T>(name);
        }
        /// <summary>
        /// Saves all changes to the database.
        /// Works like a commit-method in a transaction.
        /// </summary>
        public void SaveChanges()
        {
            this.GetService<IDocumentSession>().SaveChanges();
        }
        #endregion
    }
}
