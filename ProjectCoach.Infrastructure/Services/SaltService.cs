using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xemio.ProjectCoach.Core.Services;

namespace Xemio.ProjectCoach.Infrastructure.Services
{
    public class SaltService : ISaltService
    {
        #region Fields
        private readonly RandomNumberGenerator _randomNumberGenerator;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SaltService"/> class.
        /// </summary>
        public SaltService()
        {
            this._randomNumberGenerator = new RNGCryptoServiceProvider();
        }
        #endregion Constructors

        #region ISaltService Member
        /// <summary>
        /// Creates a new random salt.
        /// </summary>
        /// <param name="length">The length.</param>
        public byte[] CreateSalt(int length = 32)
        {
            byte[] result = new byte[length];

            this._randomNumberGenerator.GetNonZeroBytes(result);

            return result;
        }
        #endregion ISaltService Member
    }
}
