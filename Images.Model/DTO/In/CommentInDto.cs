using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Images.Model.DTO.In
{
    /// <summary>
    /// Represents a model of comment.
    /// </summary>
    public class CommentInDto
    {
        /// <summary>
        /// Gets or sets the comment content.
        /// </summary>
        /// <value>The content.</value>
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        [Required]
        [MaxLength(125)]
        public string CreatedBy { get; set; }
    }

    /// <summary>
    /// Represents a validator for <see cref="CommentInDto" />.
    /// Implements the <see cref="FluentValidation.AbstractValidator{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="FluentValidation.AbstractValidator{T}" />
    public class CommentInDtoValidator<T> : AbstractValidator<T> where T : CommentInDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentInDtoValidator{T}"/> class.
        /// </summary>
        public CommentInDtoValidator()
        {
            RuleFor(x => x.Content).NotEmpty().MaximumLength(500);
            RuleFor(x => x.CreatedBy).NotEmpty().MinimumLength(3).MaximumLength(125);
        }
    }
}
