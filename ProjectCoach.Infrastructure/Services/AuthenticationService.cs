using System.Collections.Generic;
using System.Linq;
using CuttingEdge.Conditions;
using Raven.Client;
using Raven.Client.Linq;
using Xemio.ProjectCoach.Core.Raven.Indexes;
using Xemio.ProjectCoach.Core.Services;
using Xemio.ProjectCoach.Core.Services.Abstract;
using Xemio.ProjectCoach.Entities.Users;
using Xemio.ProjectCoach.Infrastructure.Exceptions;

namespace Xemio.ProjectCoach.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="hashService">The hash creator.</param>
        public AuthenticationService(IDocumentSession session, IHashService hashService)
        {
            _session = session;
            _hashService = hashService;
        }
        #endregion Constructors

        #region Fields
        private readonly IDocumentSession _session;
        private readonly IHashService _hashService;
        #endregion Fields
        
        #region IAuthenticationService Member
        /// <summary>
        /// Authenticates the user with the given username and password.
        /// Checks if the password matches the username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <exception cref="Xemio.ProjectCoach.Infrastructure.Exceptions.UserNotFoundException"></exception>
        public bool Authenticate(string username, string password)
        {
            Condition.Requires(username)
                .IsNotNullOrWhiteSpace();
            Condition.Requires(password)
                .IsNotNullOrWhiteSpace();

            User user = this._session.Query<User, UsernameIndex>()
                .FirstOrDefault(f => f.Username == username);

            if (user == null)
                throw new UserNotFoundException(username);

            List<byte> passwordHash = this._hashService.CreateHash(password).ToList();
            passwordHash.AddRange(user.Salt);

            return passwordHash.SequenceEqual(user.PasswordHash);
        }
        #endregion IAuthenticationService Member
    }
}