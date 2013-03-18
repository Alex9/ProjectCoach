using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xemio.ProjectCoach.Entities.Projects
{
    public class Member
    {
        /// <summary>
        /// Gets or sets the user ID.
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this user can create groups.
        /// </summary>
        public bool CanCreateGroups { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this user can update/modify groups.
        /// </summary>
        public bool CanUpdateGroups { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this user can delete groups.
        /// </summary>
        public bool CanDeleteGroups { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this user can create tasks.
        /// </summary>
        public bool CanCreateTasks { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this user can update/modify tasks.
        /// </summary>
        public bool CanUpdateTasks { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this user can delete tasks.
        /// </summary>
        public bool CanDeleteTasks { get; set; }
    }
}
