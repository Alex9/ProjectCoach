using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Activation;
using Ninject.Modules;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace Xemio.ProjectCoach.Infrastructure.ServiceManagement.Modules
{
    internal class RavenModule : NinjectModule
    {
        public override void Load()
        {
            IDocumentStore documentStore = new DocumentStore
                                               {
                                                   Url = "https://ibis.ravenhq.com/databases/haefele-ProjectCoach",
                                                   ApiKey = "a301c172-7909-402f-877d-ad3af502d15d"
                                               }.Initialize();

            IndexCreation.CreateIndexes(this.GetType().Assembly, documentStore);

            this.Bind<IDocumentStore>().ToConstant(documentStore);
            this.Bind<IDocumentSession>().ToMethod(this.GetDocumentSession);
        }

        private IDocumentSession GetDocumentSession(IContext context)
        {
            return context.Kernel.Get<IDocumentStore>().OpenSession();
        }
    }
}
