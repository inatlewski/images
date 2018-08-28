﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Images.Model.DTO
{
    public class ImageDto : AuditDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}
