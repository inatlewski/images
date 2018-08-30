using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Images.Model.DTO.In
{
    /// <summary>
    /// Class CommentInDto.
    /// </summary>
    public class CommentInDto
    {
        /// <summary>
        /// Gets or sets the content.
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
    /// Class CommentInDtoValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Images.Model.DTO.In.CommentInDto}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Images.Model.DTO.In.CommentInDto}" />
    public class CommentInDtoValidator : AbstractValidator<CommentInDto> 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommentInDtoValidator"/> class.
        /// </summary>
        public CommentInDtoValidator()
        {
            RuleFor(x => x.Content).NotEmpty().MaximumLength(500);
            RuleFor(x => x.CreatedBy).NotEmpty().MinimumLength(3).MaximumLength(125);
        }
    }
}
