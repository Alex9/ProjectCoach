using Ninject;
using Ninject.Activation;
using Ninject.Modules;
using Raven.Client;

namespace Xemio.ProjectCoach.Core.ServiceManagement
{
    /// <summary>
    /// Registers the document-store and the document-session.
    /// </summary>
    public class ServiceModule : NinjectModule
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceModule"/> class.
        /// </summary>
        /// <param name="store">The document-store.</param>
        public ServiceModule(IDocumentStore store)
        {
            this._store = store;
        }
        #endregion Constructors

        #region Fields
        private readonly IDocumentStore _store;
        #endregion Fields

        #region NinjectModule Member
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void Load()
        {
            this.Bind<IDocumentStore>().ToConstant(this._store).InSingletonScope();
            this.Bind<IDocumentSession>().ToMethod(this.GetDocumentSession);
        }
        #endregion NinjectModule Member

        #region Private Methods
        private IDocumentSession GetDocumentSession(IContext context)
        {
            return context.Kernel.Get<IDocumentStore>().OpenSession();
        }
        #endregion Private Methods
    }
}
