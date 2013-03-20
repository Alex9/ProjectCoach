using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Xemio.ProjectCoach.Core.Services;
using Xemio.ProjectCoach.Infrastructure.Services;

namespace Xemio.ProjectCoach.Infrastructure.ServiceManagement.Modules
{
    internal class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IAuthenticationService>().To<AuthenticationService>();
            this.Bind<IDocumentService>().To<DocumentService>();
            this.Bind<IHashService>().To<SHA256HashService>();
        }
    }
}