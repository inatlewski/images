using System.Collections.Generic;

namespace Images.Model.DTO.Out
{
    /// <summary>
    /// Represents a model of list of images.
    /// </summary>
    public class ImageListOutDto
    {
        /// <summary>
        /// Gets or sets the list of images.
        /// </summary>
        /// <value>The list of images.</value>
        public IList<ImageOutDto> Images { get; set; } = new List<ImageOutDto>();
    }
}
