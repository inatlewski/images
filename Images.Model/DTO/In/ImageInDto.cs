using FluentValidation;

namespace Images.Model.DTO.In
{
    /// <summary>
    /// Class ImageInDto.
    /// </summary>
    public class ImageInDto
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public string CreatedBy { get; set; }
    }

    /// <summary>
    /// Class ImageInDtoValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{Images.Model.DTO.In.ImageInDto}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{Images.Model.DTO.In.ImageInDto}" />
    public class ImageInDtoValidator : AbstractValidator<ImageInDto>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageInDtoValidator"/> class.
        /// </summary>
        public ImageInDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(125);
            RuleFor(x => x.CreatedBy).NotEmpty().MinimumLength(3).MaximumLength(125);
        }
    }
}
