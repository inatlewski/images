using System.Collections.Generic;

namespace Images.Model.DTO.Out
{
    public class ImageOutDto : AuditOutDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public ICollection<CommentOutDto> Comments { get; set; } = new List<CommentOutDto>();
    }
}
