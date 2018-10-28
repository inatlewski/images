using System;

namespace Images.Model.DTO.Out
{
    /// <summary>
    /// Represents a model of auditable object.
    /// </summary>
    public class AuditOutDto
    {
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public DateTime CreatedDate { get; set; }
    }
}
