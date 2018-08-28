using System;
using System.Collections.Generic;
using System.Text;

namespace Images.Model.Entities
{
    public class Image : Auditable
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
