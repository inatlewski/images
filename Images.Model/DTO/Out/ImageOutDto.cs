using System.Collections.Generic;

namespace Images.Model.DTO.Out
{
    /// <summary>
    /// Class ImageOutDto.
    /// Implements the <see cref="Images.Model.DTO.Out.AuditOutDto" />
    /// </summary>
    /// <seealso cref="Images.Model.DTO.Out.AuditOutDto" />
    public class ImageOutDto : AuditOutDto
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
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the comments.
        /// </summary>
        /// <value>The comments.</value>
        public ICollection<CommentOutDto> Comments { get; set; } = new List<CommentOutDto>();
    }
}
