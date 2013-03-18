using System.Collections.Generic;

namespace Xemio.ProjectCoach.Entities.Documents
{
    public interface IDocumentContainer
    {
        /// <summary>
        /// Gets or sets the documents.
        /// </summary>
        IList<Document> Documents { get; set; }
    }
}