using System;
using System.ComponentModel.DataAnnotations;
using Images.Model.Entities.Interfaces;

namespace Images.Model.Entities
{
    /// <summary>
    /// Class BaseEntity.
    /// Implements the <see cref="Images.Model.Entities.Interfaces.IAuditable" />
    /// Implements the <see cref="Images.Model.Entities.Interfaces.IEntity" />
    /// </summary>
    /// <seealso cref="Images.Model.Entities.Interfaces.IAuditable" />
    /// <seealso cref="Images.Model.Entities.Interfaces.IEntity" />
    public class BaseEntity : IAuditable, IEntity
    {
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        [Required]
        [MaxLength(125)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
