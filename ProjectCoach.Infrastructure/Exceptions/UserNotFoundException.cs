using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Xemio.ProjectCoach.Infrastructure.Exceptions
{
    [Serializable]
    public class UserNotFoundException : XemioException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserNotFoundException"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        public UserNotFoundException(string username) 
            : base(ExceptionMessages.UserNotFound, username)
        {
            this.Username = username;
        }

        /// <summary>
        /// Gets the username.
        /// </summary>
        public string Username { get; private set; }
    }
}
