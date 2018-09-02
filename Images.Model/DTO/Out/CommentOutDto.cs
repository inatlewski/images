namespace Images.Model.DTO.Out
{
    /// <summary>
    /// Represents a model of comment.
    /// Implements the <see cref="Images.Model.DTO.Out.AuditOutDto" />
    /// </summary>
    /// <seealso cref="Images.Model.DTO.Out.AuditOutDto" />
    public class CommentOutDto : AuditOutDto
    {
        /// <summary>
        /// Gets or sets the comment identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the comment content.
        /// </summary>
        /// <value>The comment content.</value>
        public string Content { get; set; }
    }
}
