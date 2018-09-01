using FluentValidation;

namespace Images.Model.DTO.In
{
    /// <summary>
    /// Represents a model of image to update.
    /// Implements the <see cref="Images.Model.DTO.In.ImageInDto" />
    /// </summary>
    /// <seealso cref="Images.Model.DTO.In.ImageInDto" />
    public class UpdateImageInDto : ImageInDto
    {
        /// <summary>
        /// Gets or sets the image identifier.
        /// </summary>
        /// <value>The image identifier.</value>
        public int Id { get; set; }
    }

    /// <summary>
    /// Represents a validator for <see cref="UpdateImageInDto" />.
    /// Implements the <see cref="Images.Model.DTO.In.ImageInDtoValidator{Images.Model.DTO.In.UpdateImageInDto}" />
    /// </summary>
    /// <seealso cref="Images.Model.DTO.In.ImageInDtoValidator{Images.Model.DTO.In.UpdateImageInDto}" />
    public class UpdateImageInDtoValidator : ImageInDtoValidator<UpdateImageInDto>
    {
    }
}