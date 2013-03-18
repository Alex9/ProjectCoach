using System.IO;
using Xemio.ProjectCoach.Entities.Documents;
using Xemio.ProjectCoach.Entities.Users;

namespace Xemio.ProjectCoach.Core.Services.Abstract
{
    public interface IDocumentService
    {
        /// <summary>
        /// Adds a new document to the given phase.
        /// </summary>
        /// <param name="container">The container holding the document.</param>
        /// <param name="data">The data for the document.</param>
        /// <param name="name">The name for the document.</param>
        /// <param name="creator">The creator of the document.</param>
        Document AddDocument(IDocumentContainer container, Stream data, string name, User creator);
    }
}
