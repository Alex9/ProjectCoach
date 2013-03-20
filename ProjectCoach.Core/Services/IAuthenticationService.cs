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
    }
}
