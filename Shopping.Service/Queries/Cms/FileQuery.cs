using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries.Cms
{
    public class FileQuery:Query
    {
      
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string OriginalName { get; set; }
        public string Alt { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Extension { get; set; }

    }
}
