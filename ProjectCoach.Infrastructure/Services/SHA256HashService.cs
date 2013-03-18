using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CuttingEdge.Conditions;
using Xemio.ProjectCoach.Core.Services;
using Xemio.ProjectCoach.Core.Services.Abstract;

namespace Xemio.ProjectCoach.Infrastructure.Services
{
    public class SHA256HashService : IHashService
    {
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
    }
}
