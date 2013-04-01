using System.Threading.Tasks;
using Xemio.ProjectCoach.Entities.Users;

namespace Xemio.ProjectCoach.Core.Services
{
    /// <summary>
    /// Provides authentication methods.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticates the user with the given username and password.
        /// Checks if the password matches the username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        bool Authenticate(string username, string password);
        /// <summary>
        /// Registers a new user with the given username and password.
        /// The username needs to be unique.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        User Register(string username, string password, string emailAddress);
    }
}
