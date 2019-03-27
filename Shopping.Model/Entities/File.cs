using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class File:BaseEntity
    {
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Alt { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Extension { get; set; }
    }
}
