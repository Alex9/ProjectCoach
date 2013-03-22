using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CuttingEdge.Conditions;
using Xemio.ProjectCoach.Core.Services;

namespace Xemio.ProjectCoach.Infrastructure.Services
{
    /// <summary>
    /// Provides hashing methods.
    /// </summary>
    public class SHA256HashService : IHashService
    {
        #region IHashService Member
        /// <summary>
        /// Creates a hash of the given input bytes.
        /// </summary>
        /// <param name="input">The input bytes.</param>
        public byte[] CreateHash(byte[] input)
        {
            Condition.Requires(input)
                .IsNotNull()
                .IsNotEmpty();

            return SHA256.Create().ComputeHash(input);
        }
        /// <summary>
        /// Creates a hash of the given input string.
        /// </summary>
        /// <param name="input">The input string.</param>
        public byte[] CreateHash(string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            return this.CreateHash(bytes);
        }

        /// <summary>
        /// Creates a hash of the given input bytes and appends the salt.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="salt">The salt.</param>
        public byte[] CreateHash(byte[] input, byte[] salt)
        {
            List<byte> hash = this.CreateHash(input).ToList();
            hash.AddRange(salt);

            return hash.ToArray();
        }

        /// <summary>
        /// Creates a hash of the given input string and appends the salt.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="salt">The salt.</param>
        public byte[] CreateHash(string input, byte[] salt)
        {
            return this.CreateHash(Encoding.UTF8.GetBytes(input), salt);
        }

        /// <summary>
        /// Returns true when the input equals the expected value.
        /// </summary>
        /// <param name="input">The input value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="salt">The salt.</param>
        public bool EqualsHash(byte[] input, byte[] expected, byte[] salt)
        {
            List<byte> inputList = this.CreateHash(input).ToList(); 
            inputList.AddRange(salt);

            return inputList.SequenceEqual(expected);
        }
        /// <summary>
        /// Returns true when the input equals the expected value.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="salt">The salt.</param>
        public bool EqualsHash(string input, byte[] expected, byte[] salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            return this.EqualsHash(bytes, expected, salt);
        }
        #endregion IHashService Member
    }
}
