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
using Xemio.ProjectCoach.Core.Services.Abstract;
using Xemio.ProjectCoach.Entities.Documents;
using Xemio.ProjectCoach.Entities.Projects;
using Xemio.ProjectCoach.Entities.Users;

namespace Xemio.ProjectCoach.Infrastructure.Services
{
    public class DocumentService : IDocumentService
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentService"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public DocumentService(IDocumentSession session)
        {
            _session = session;
        }
        #endregion Constructors

        #region Fields
        private readonly IDocumentSession _session;
        #endregion Fields

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

            string attachementID = this.CreateNewAttachementID();

            this._session.Advanced.DocumentStore.DatabaseCommands.PutAttachment(attachementID, null, data, null);

            var document = new Document
            {
                CreatedByUserID = creator.ID,
                Name = name,
                AttachementID = attachementID
            };

            container.Documents.Add(document);

            return document;
        }
        #endregion IDocumentService Member

        #region Private Methods
        /// <summary>
        /// Creates a new (random) attachement-id.
        /// </summary>
        private string CreateNewAttachementID()
        {
            return Guid.NewGuid().ToString();
        }
        #endregion Private Methods
    }
}
