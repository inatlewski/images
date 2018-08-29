using System.Collections.Generic;

namespace Images.Model.DTO
{
    public class ImageListDto
    {
        public IList<ImageDto> Images { get; set; } = new List<ImageDto>();
    }
}
