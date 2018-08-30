using System;

namespace Images.Model.Entities.Interfaces
{
    /// <summary>
    /// Interface IAuditable
    /// </summary>
    public interface IAuditable
    {
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        DateTime CreatedDate { get; set; }
    }
}
