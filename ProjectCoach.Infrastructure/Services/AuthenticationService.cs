using System.Collections.Generic;
using System.Linq;
using CuttingEdge.Conditions;
using Raven.Client;
using Xemio.ProjectCoach.Core.Exceptions;
using Xemio.ProjectCoach.Core.Services;
using Xemio.ProjectCoach.Entities.Users;
using UsernameIndex = Xemio.ProjectCoach.Infrastructure.Raven.Indexes.UsernameIndex;

namespace Xemio.ProjectCoach.Infrastructure.Services
{
    /// <summary>
    /// Provides authentication methods.
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields
        private readonly IDocumentSession _documentSession;
        private readonly IHashService _hashService;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        /// <param name="documentSession">The documentSession.</param>
        /// <param name="hashService">The hash creator.</param>
        public AuthenticationService(IDocumentSession documentSession, IHashService hashService)
        {
            _documentSession = documentSession;
            _hashService = hashService;
        }
        #endregion Constructors
        
        #region IAuthenticationService Member
        /// <summary>
        /// Authenticates the user with the given username and password.
        /// Checks if the password matches the username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <exception cref="Xemio.ProjectCoach.Core.Exceptions.UserNotFoundException">Throws if no user with the given username was found.</exception>
        public bool Authenticate(string username, string password)
        {
            Condition.Requires(username, "username")
                .IsNotNullOrWhiteSpace();
            Condition.Requires(password, "password")
                .IsNotNullOrWhiteSpace();

            User user = this._documentSession.Query<User, UsernameIndex>()
                .FirstOrDefault(f => f.Username == username);

            if (user == null)
                throw new UserNotFoundException(username);

            return this._hashService.EqualsHash(password, user.PasswordHash, user.Salt);
        }
        #endregion IAuthenticationService Member
    }
}