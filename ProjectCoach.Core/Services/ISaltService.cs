using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xemio.ProjectCoach.Core.Services
{
    public interface ISaltService
    {
        /// <summary>
        /// Creates a new random salt.
        /// </summary>
        /// <param name="length">The length.</param>
        byte[] CreateSalt(int length = 32);
    }
}
