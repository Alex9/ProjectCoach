using NUnit.Framework;
using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using Xemio.ProjectCoach.Infrastructure.ServiceManagement;

namespace Xemio.ProjectCoach.Tests.Services.Base
{
    [TestFixture]
    public class RavenTest
    {
        protected IDocumentStore DocumentStore { get; private set; }

        [TestFixtureSetUp]
        public virtual void SetUp()
        {
            this.DocumentStore = new EmbeddableDocumentStore
                                      {
                                          RunInMemory = true
                                      }.Initialize();

            IndexCreation.CreateIndexes(typeof(ServiceManager).Assembly, this.DocumentStore);
        }

        [TestFixtureTearDown]
        public virtual void TearDown()
        {
            this.DocumentStore.Dispose();
        }
    }
}
