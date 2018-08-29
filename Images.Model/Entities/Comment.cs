using System.ComponentModel.DataAnnotations;

namespace Images.Model.Entities
{
    public class Comment : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        public Image Image { get; set; }
    }
}
