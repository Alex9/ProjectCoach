using System.Collections.Generic;
using Xemio.ProjectCoach.Entities.Chats;
using Xemio.ProjectCoach.Entities.Documents;

namespace Xemio.ProjectCoach.Entities.Projects
{
    public class Phase : IDocumentContainer
    {
        /// <summary>
        /// Gets or sets the name of the phase.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets a description of the phase.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the sub phases.
        /// </summary>
        public IList<Phase> SubPhases { get; set; }
        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public PhaseState Type { get; set; }
        /// <summary>
        /// Gets or sets the users working on this phase.
        /// </summary>
        public IList<string> UsersWorkingOn { get; set; }
        /// <summary>
        /// Gets or sets the documents of this phase.
        /// </summary>
        public IList<Document> Documents { get; set; }
        /// <summary>
        /// Gets or sets the chat.
        /// </summary>
        public Chat Chat { get; set; }
    }
}