using System;
using System.Collections.Generic;
using System.Text;

namespace Images.Model.Entities
{
    public class Comment : Auditable
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public Image Image { get; set; }
    }
}
