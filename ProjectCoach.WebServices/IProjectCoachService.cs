using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Xemio.ProjectCoach.WebServices
{
    [ServiceContract]
    public interface IProjectCoachService
    {
        object ExecuteService(string serviceName, object[] arguments);
    }
}
