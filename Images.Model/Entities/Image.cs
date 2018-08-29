using System.Collections.Generic;

namespace Images.Model.Entities
{
    public class Image : BaseEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
