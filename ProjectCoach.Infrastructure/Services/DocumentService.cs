using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CuttingEdge.Conditions;
using Raven.Client;
using Raven.Client.Connection;
using Raven.Json.Linq;
using Xemio.ProjectCoach.Core.Services;
using Xemio.ProjectCoach.Entities.Documents;
using Xemio.ProjectCoach.Entities.Projects;
using Xemio.ProjectCoach.Entities.Users;

namespace Xemio.ProjectCoach.Infrastructure.Services
{
    /// <summary>
    /// Provides document-management methods.
    /// </summary>
    public class DocumentService : IDocumentService
    {
        #region Fields
        private readonly IDocumentSession _documentSession;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentService"/> class.
        /// </summary>
        /// <param name="documentSession">The documentSession.</param>
        public DocumentService(IDocumentSession documentSession)
        {
            _documentSession = documentSession;
        }
        #endregion Constructors

        #region IDocumentService Member
        /// <summary>
        /// Adds a new document to the given phase.
        /// </summary>
        /// <param name="container">The container holding the document.</param>
        /// <param name="data">The data for the document.</param>
        /// <param name="name">The name for the document.</param>
        /// <param name="creator">The creator of the document.</param>
        public Document AddDocument(IDocumentContainer container, Stream data, string name, User creator)
        {
            Condition.Requires(container)
               .IsNotNull();
            Condition.Requires(data)
                .IsNotNull()
                .Evaluate(f => f.Length > 0);
            Condition.Requires(name)
                .IsNotNullOrWhiteSpace();
            Condition.Requires(creator)
                .IsNotNull();

            string attachementId = this.CreateNewAttachementId();

            this._documentSession.Advanced.DocumentStore.DatabaseCommands.PutAttachment(attachementId, null, data, null);

            var document = new Document
            {
                CreatedByUserId = creator.Id,
                Name = name,
                AttachementId = attachementId
            };

            container.Documents.Add(document);

            return document;
        }
        #endregion IDocumentService Member

        #region Private Methods
        /// <summary>
        /// Creates a new (random) attachement-id.
        /// </summary>
        private string CreateNewAttachementId()
        {
            return Guid.NewGuid().ToString();
        }
        #endregion Private Methods
    }
}
