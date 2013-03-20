using System;

namespace Xemio.ProjectCoach.Core.Exceptions
{
    /// <summary>
    /// Gets thrown when no user with the given username was found.
    /// </summary>
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
