using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Images.Model.Entities
{
    public class Image : BaseEntity
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [MaxLength(250)]
        public string Url { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
