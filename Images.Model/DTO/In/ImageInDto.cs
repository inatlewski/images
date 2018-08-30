using FluentValidation;

namespace Images.Model.DTO.In
{
    public class ImageInDto
    {
        public string Description { get; set; }

        public string CreatedBy { get; set; }
    }

    public class ImageInDtoValidator : AbstractValidator<ImageInDto> {
        public ImageInDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(125);
            RuleFor(x => x.CreatedBy).NotEmpty().MinimumLength(3).MaximumLength(125);
        }
    }
}
