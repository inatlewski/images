using System;

namespace Images.Model.Entities.Interfaces
{
    public interface IAuditable
    {
        string CreatedBy { get; set; }

        DateTime CreatedDate { get; set; }
    }
}
