using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace Images.Model.DTO.In
{
    public class CommentInDto
    {
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        [Required]
        [MaxLength(125)]
        public string CreatedBy { get; set; }
    }

    public class CommentInDtoValidator : AbstractValidator<CommentInDto> {
        public CommentInDtoValidator()
        {
            RuleFor(x => x.Content).NotEmpty().MaximumLength(500);
            RuleFor(x => x.CreatedBy).NotEmpty().MinimumLength(3).MaximumLength(125);
        }
    }
}
