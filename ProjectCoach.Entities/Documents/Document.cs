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
        /// Gets or sets the attachement Id.
        /// </summary>
        public string AttachementId { get; set; }
        /// <summary>
        /// Gets or sets the created by user Id.
        /// </summary>
        public string CreatedByUserId { get; set; }
    }
}
