namespace Xemio.ProjectCoach.Core.Services.Abstract
{
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
    }
}