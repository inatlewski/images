using FluentValidation;

namespace Images.Model.DTO.In
{
    /// <summary>
    /// Represents a model of comment to update.
    /// Implements the <see cref="Images.Model.DTO.In.CommentInDto" />
    /// </summary>
    /// <seealso cref="Images.Model.DTO.In.CommentInDto" />
    public class UpdateCommentInDto : CommentInDto
    {
        /// <summary>
        /// Gets or sets the comment identifier.
        /// </summary>
        /// <value>The comment identifier.</value>
        public int Id { get; set; }
    }

    /// <summary>
    /// Represents a validator for <see cref="UpdateCommentInDto" />.
    /// Implements the <see cref="Images.Model.DTO.In.CommentInDtoValidator{Images.Model.DTO.In.UpdateCommentInDto}" />
    /// </summary>
    /// <seealso cref="Images.Model.DTO.In.CommentInDtoValidator{Images.Model.DTO.In.UpdateCommentInDto}" />
    public class UpdateCommentInDtoValidator : CommentInDtoValidator<UpdateCommentInDto>
    {
    }
}