using System.Collections.Generic;

namespace Images.Model.DTO.Out
{
    public class ImageListOutDto
    {
        public IList<ImageOutDto> Images { get; set; } = new List<ImageOutDto>();
    }
}
