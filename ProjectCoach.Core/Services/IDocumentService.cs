using System.IO;
using System.Threading.Tasks;
using Xemio.ProjectCoach.Entities.Documents;
using Xemio.ProjectCoach.Entities.Users;

namespace Xemio.ProjectCoach.Core.Services
{
    /// <summary>
    /// Provides document-management methods.
    /// </summary>
    public interface IDocumentService
    {
        /// <summary>
        /// Adds a new document to the given phase.
        /// </summary>
        /// <param name="container">The container holding the document.</param>
        /// <param name="stream">The stream for the document.</param>
        /// <param name="name">The name for the document.</param>
        /// <param name="creator">The creator of the document.</param>
        Document AddDocument(IDocumentContainer container, Stream stream, string name, User creator);
        /// <summary>
        /// Returns the stream of the document.
        /// </summary>
        /// <param name="document">The document.</param>
        Stream GetDocumentData(Document document);
    }
}
