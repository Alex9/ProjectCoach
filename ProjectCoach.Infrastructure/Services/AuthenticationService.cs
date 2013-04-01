using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuttingEdge.Conditions;
using Raven.Client;
using Xemio.ProjectCoach.Core.Exceptions;
using Xemio.ProjectCoach.Core.Services;
using Xemio.ProjectCoach.Core.Extensions;
using Xemio.ProjectCoach.Entities.Users;
using Xemio.ProjectCoach.Infrastructure.RavenDB.Indexes;

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
        private readonly ISaltService _saltService;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        /// <param name="documentSession">The documentSession.</param>
        /// <param name="hashService">The hash service.</param>
        /// <param name="saltService">The salt service.</param>
        public AuthenticationService(IDocumentSession documentSession, IHashService hashService, ISaltService saltService)
        {
            _documentSession = documentSession;
            _hashService = hashService;
            _saltService = saltService;
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

            User user = this._documentSession.Query<User, Users_ByUsername>()
                .FirstOrDefault(f => f.Username == username);

            if (user == null)
                throw new UserNotFoundException(username);

            AuthenticationData authenticationData = this._documentSession.Query<AuthenticationData, AuthenticationDatas_ByUserId>()
                .First(f => f.UserId == user.Id);

            return this._hashService.EqualsHash(password, authenticationData.PasswordHash, authenticationData.Salt);
        }
        /// <summary>
        /// Registers a new user with the given username and password.
        /// The username needs to be unique.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="emailAddress"></param>
        /// <exception cref="Xemio.ProjectCoach.Core.Exceptions.UsernameAlreadyExistsException"></exception>
        public User Register(string username, string password, string emailAddress)
        {
            Condition.Requires(username, "username")
                .IsNotNullOrWhiteSpace();
            Condition.Requires(password, "password")
                .IsNotNullOrWhiteSpace()
                .IsLongerOrEqual(6);
            Condition.Requires(emailAddress, "emailAddress")
                .IsNotNullOrWhiteSpace()
                .Evaluate(f => f.IsEmailAddress());

            bool usernameExists = this._documentSession.Query<User, Users_ByUsername>()
                .Any(f => f.Username == username);

            if (usernameExists)
                throw new UsernameAlreadyExistsException(username);

            var user = new User
                           {
                               Username = username,
                               EmailAddress = emailAddress
                           };

            this._documentSession.Store(user);

            byte[] salt = this._saltService.CreateSalt();
            byte[] passwordHash = this._hashService.CreateHash(password, salt);

            var authenticationData = new AuthenticationData
                                         {
                                             UserId = user.Id,
                                             Salt = salt,
                                             PasswordHash = passwordHash
                                         };

            this._documentSession.Store(authenticationData);

            return user;
        }
        #endregion IAuthenticationService Member
    }
}