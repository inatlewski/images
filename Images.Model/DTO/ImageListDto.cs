using System;
using System.Collections.Generic;
using System.Text;

namespace Images.Model.DTO
{
    public class ImageListDto
    {
        public IList<ImageDto> Images { get; set; } = new List<ImageDto>();
    }
}
