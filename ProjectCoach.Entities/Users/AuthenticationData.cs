namespace Xemio.ProjectCoach.Entities.Users
{
    public class AuthenticationData : AggregateRoot
    {
        #region IAuthenticationData Members
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public string UserId { get; set; }
        #endregion

        /// <summary>
        /// Gets or sets the password hash.
        /// </summary>
        public byte[] PasswordHash { get; set; }
        /// <summary>
        /// Gets or sets the salt.
        /// </summary>
        public byte[] Salt { get; set; }
    }
}
