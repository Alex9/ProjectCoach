using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xemio.ProjectCoach.Core.ServiceManagement
{
    /// <summary>
    /// A basic service manager class providing methods to open a new service session.
    /// </summary>
    public interface IServiceManager
    {
        /// <summary>
        /// Opens a new service session.
        /// </summary>
        IServiceSession OpenSession();
    }
}
