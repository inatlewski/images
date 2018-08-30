namespace Images.Model.DTO.Out
{
    /// <summary>
    /// Class CommentOutDto.
    /// Implements the <see cref="Images.Model.DTO.Out.AuditOutDto" />
    /// </summary>
    /// <seealso cref="Images.Model.DTO.Out.AuditOutDto" />
    public class CommentOutDto : AuditOutDto
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
        public string Content { get; set; }
    }
}
