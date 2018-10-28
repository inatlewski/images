using FluentValidation;

namespace Images.Model.DTO.In
{
    /// <summary>
    /// Represents a model of image.
    /// </summary>
    public class ImageInDto
    {
        /// <summary>
        /// Gets or sets a description of the image.
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
    /// Represents a validator for <see cref="ImageInDto" />.
    /// Implements the <see cref="FluentValidation.AbstractValidator{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="FluentValidation.AbstractValidator{T}" />
    public class ImageInDtoValidator<T> : AbstractValidator<T> where T : ImageInDto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageInDtoValidator{T}"/> class.
        /// </summary>
        public ImageInDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(125);
            RuleFor(x => x.CreatedBy).NotEmpty().MinimumLength(3).MaximumLength(125);
        }
    }
}
