using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Xemio.ProjectCoach.Core.Extensions
{
    public static class StringExtensions
    {
        private const string EMAIL_PATTERN = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                                             @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

        /// <summary>
        /// Determines whether this string is a valid email address.
        /// </summary>
        /// <param name="email">The string.</param>
        public static bool IsEmailAddress(this string email)
        {
            try
            {
                return Regex.IsMatch(email, EMAIL_PATTERN, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException exception)
            {
                return false;
            }
        }
    }
}
