using System.Collections.Generic;

namespace Images.Model.DTO.Out
{
    /// <summary>
    /// Class ImageListOutDto.
    /// </summary>
    public class ImageListOutDto
    {
        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>The images.</value>
        public IList<ImageOutDto> Images { get; set; } = new List<ImageOutDto>();
    }
}
