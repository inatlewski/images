using System;
using Images.Model.Entities.Interfaces;

namespace Images.Model.Entities
{
    public class BaseEntity : IAuditable, IEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
