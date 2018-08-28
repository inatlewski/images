using System;
using System.Collections.Generic;
using System.Text;

namespace Images.Model.Entities
{
    public class Auditable
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
