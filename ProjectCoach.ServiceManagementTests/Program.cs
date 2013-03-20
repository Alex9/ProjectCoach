using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;
using Xemio.ProjectCoach.Core.ServiceManagement;
using Xemio.ProjectCoach.Core.Services;
using Xemio.ProjectCoach.Entities.Users;
using Xemio.ProjectCoach.Infrastructure.ServiceManagement;

namespace ProjectCoach.ServiceManagementTests
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceManager serviceManager = new ServiceManager();
            using (IServiceSession session = serviceManager.OpenSession())
            {
                IDocumentSession documentSession = session.GetService<IDocumentSession>();

                for (int i = 0; i < 100; i++)
                { 
                    documentSession.Store(new User
                                              {
                                                  Username = "Günther " + i,
                                                  EmailAddress = "Günther" + i + "@gmx.de",
                                                  PasswordHash = new byte[] { 0x02, 0x03 },
                                                  Salt = new byte[] { 0x02, 0x04 }
                                              });
                }
            }

            using (IServiceSession session = serviceManager.OpenSession())
            {
                session.GetService<IDocumentService>();
            }
        }
    }
}
