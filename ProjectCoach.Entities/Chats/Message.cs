using System;

namespace Xemio.ProjectCoach.Entities.Chats
{
    public class Message
    {
        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// Gets or sets the sent date.
        /// </summary>
        public DateTime SentDate { get; set; }
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public string Content { get; set; }
    }
}