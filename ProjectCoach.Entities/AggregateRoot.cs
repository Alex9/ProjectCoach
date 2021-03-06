﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xemio.ProjectCoach.Entities
{
    /// <summary>
    /// A root entity for querying.
    /// </summary>
    public abstract class AggregateRoot
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public string Id { get; set; }

        #region Overriden Methods
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        public override bool Equals(object obj)
        {
            AggregateRoot aggregateRoot = obj as AggregateRoot;
            if (aggregateRoot == null)
            {
                return false;
            }

            return this.Id == aggregateRoot.Id;
        }
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        #endregion Overriden Methods
    }
}
