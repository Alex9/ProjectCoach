using System.Collections.Generic;
using Xemio.ProjectCoach.Entities.Projects;

namespace Xemio.ProjectCoach.Entities.Chats
{
    public class Chat : AggregateRoot
    {
        /// <summary>
        /// Gets or sets the IDs from the users in the chat.
        /// </summary>
        public IList<string> UserIDs { get; set; }
        /// <summary>
        /// Gets or sets the title of the chat.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        public IList<Message> Messages { get; set; }
    }
}
