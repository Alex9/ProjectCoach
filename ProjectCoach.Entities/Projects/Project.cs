using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xemio.ProjectCoach.Entities.Documents;

namespace Xemio.ProjectCoach.Entities.Projects
{
    public class Project : AggregateRoot, IDocumentContainer
    {
        /// <summary>
        /// Gets or sets the name of the project.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets a tag list for the project.
        /// </summary>
        public IList<string> Tags { get; set; }
        /// <summary>
        /// Gets or sets the phases.
        /// </summary>
        public IList<Phase> Phases { get; set; }
        /// <summary>
        /// Gets or sets the IDs of all normal members.
        /// They are able to finish tasks.
        /// </summary>
        public IList<Member> MemberIDs { get; set; }
        /// <summary>
        /// Gets or sets the documents.
        /// </summary>
        public IList<Document> Documents { get; set; }
    }
}
