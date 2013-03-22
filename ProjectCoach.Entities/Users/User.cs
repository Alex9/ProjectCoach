using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xemio.ProjectCoach.Entities.Users
{
    /// <summary>
    /// A user.
    /// </summary>
    public class User : AggregateRoot
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        public string EmailAddress { get; set; }
    }
}
