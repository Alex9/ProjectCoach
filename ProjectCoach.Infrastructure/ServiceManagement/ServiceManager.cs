using System.Reflection;
using CuttingEdge.Conditions;
using Ninject;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;
using Xemio.ProjectCoach.Core.ServiceManagement;
using Xemio.ProjectCoach.Infrastructure.ServiceManagement.Modules;

namespace Xemio.ProjectCoach.Infrastructure.ServiceManagement
{
    /// <summary>
    /// Handles session creation.
    /// </summary>
    public class ServiceManager : IServiceManager
    {
        #region Fields
        private readonly IKernel _ninjectKernel = new StandardKernel();
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceManager"/> class.
        /// </summary>
        public ServiceManager()
        {
            this._ninjectKernel.Load(new RavenModule());
            this._ninjectKernel.Load(new ServiceModule());
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Opens a new service session.
        /// </summary>
        public IServiceSession OpenSession()
        {
            return new ServiceSession(this._ninjectKernel);
        }
        #endregion Methods
    }
}
