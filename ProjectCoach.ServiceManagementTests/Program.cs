using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;
using Xemio.ProjectCoach.Core.ServiceManagement;
using Xemio.ProjectCoach.Core.Services;
using Xemio.ProjectCoach.Entities.Users;
using Xemio.ProjectCoach.Infrastructure.Raven.Indexes;
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
                IAuthenticationService authenticationService = session.GetService<IAuthenticationService>();
                
                bool result = authenticationService.Authenticate("haefele", "123456");
                Console.WriteLine(result);

                session.SaveChanges();
            }

            Console.ReadLine();
        }
    }
}
