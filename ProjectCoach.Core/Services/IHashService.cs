using System.Threading.Tasks;

namespace Xemio.ProjectCoach.Core.Services
{
    /// <summary>
    /// Provides hashing methods.
    /// </summary>
    public interface IHashService
    {
        /// <summary>
        /// Creates a hash of the given input bytes.
        /// </summary>
        /// <param name="input">The input bytes.</param>
        byte[] CreateHash(byte[] input);

        /// <summary>
        /// Creates a hash of the given input string.
        /// </summary>
        /// <param name="input">The input string.</param>
        byte[] CreateHash(string input);

        /// <summary>
        /// Creates a hash of the given input bytes and appends the salt.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="salt">The salt.</param>
        byte[] CreateHash(byte[] input, byte[] salt);

        /// <summary>
        /// Creates a hash of the given input string and appends the salt.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="salt">The salt.</param>
        byte[] CreateHash(string input, byte[] salt);

        /// <summary>
        /// Returns true when the input equals the expected value.
        /// </summary>
        /// <param name="input">The input value.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="salt">The salt.</param>
        bool EqualsHash(byte[] input, byte[] expected, byte[] salt);

        /// <summary>
        /// Returns true when the input equals the expected value.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="expected">The expected value.</param>
        /// <param name="salt">The salt.</param>
        bool EqualsHash(string input, byte[] expected, byte[] salt);
    }
}