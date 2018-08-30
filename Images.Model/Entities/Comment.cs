using System.ComponentModel.DataAnnotations;

namespace Images.Model.Entities
{
    /// <summary>
    /// Class Comment.
    /// Implements the <see cref="Images.Model.Entities.BaseEntity" />
    /// </summary>
    /// <seealso cref="Images.Model.Entities.BaseEntity" />
    public class Comment : BaseEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>The content.</value>
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        public Image Image { get; set; }
    }
}
