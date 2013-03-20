using System;

namespace Xemio.ProjectCoach.Core.Exceptions
{
    /// <summary>
    /// Base exception for xemio projects.
    /// </summary>
    [Serializable]
    public abstract class XemioException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XemioException"/> class.
        /// Creates the message by inserting the arguments with string.Format.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="arguments">The arguments.</param>
        protected XemioException(string message, params object[] arguments) 
            : base(string.Format(message, arguments))
        {
        }
    }
}
