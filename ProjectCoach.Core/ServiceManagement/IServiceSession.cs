using System;

namespace Xemio.ProjectCoach.Core.ServiceManagement
{
    /// <summary>
    /// Defines all methods a service session has to implement.
    /// Should also work as an unit-of-work.
    /// </summary>
    public  interface IServiceSession : IDisposable
    {
        /// <summary>
        /// Gets the given service.
        /// </summary>
        /// <typeparam name="T">The type of the service.</typeparam>
        T GetService<T>();
        /// <summary>
        /// Gets the given service.
        /// Returns the type because of it's name.
        /// </summary>
        /// <typeparam name="T">The type of the service.</typeparam>
        /// <param name="name">The name.</param>
        T GetService<T>(string name);
        /// <summary>
        /// Saves changes.
        /// </summary>
        void SaveChanges();
    }
}