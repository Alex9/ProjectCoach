namespace Xemio.ProjectCoach.Entities.Documents
{
    public class Document : AggregateRoot
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the attachement ID.
        /// </summary>
        public string AttachementID { get; set; }
        /// <summary>
        /// Gets or sets the created by user ID.
        /// </summary>
        public string CreatedByUserID { get; set; }
    }
}
