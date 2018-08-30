using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Images.Model.Entities
{
    /// <summary>
    /// Class Image.
    /// Implements the <see cref="Images.Model.Entities.BaseEntity" />
    /// </summary>
    /// <seealso cref="Images.Model.Entities.BaseEntity" />
    public class Image : BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        [Required]
        [MaxLength(250)]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>The comments.</value>
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
