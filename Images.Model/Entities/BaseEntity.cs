using System;
using System.ComponentModel.DataAnnotations;
using Images.Model.Entities.Interfaces;

namespace Images.Model.Entities
{
    public class BaseEntity : IAuditable, IEntity
    {
        [Required]
        [MaxLength(125)]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
