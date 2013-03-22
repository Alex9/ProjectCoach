using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xemio.ProjectCoach.Core.Exceptions
{
    /// <summary>
    /// Gets thrown when the given username already exists.
    /// </summary>
    [Serializable]
    public class UsernameAlreadyExistsException : XemioException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsernameAlreadyExistsException"/> class.
        /// </summary>
        /// <param name="username">The username.</param>
        public UsernameAlreadyExistsException(string username)
            : base(ExceptionMessages.UsernameAlreadyExists, username)
        {
            this.Username = username;
        }

        /// <summary>
        /// Gets the username.
        /// </summary>
        public string Username { get; private set; }
    }
}
