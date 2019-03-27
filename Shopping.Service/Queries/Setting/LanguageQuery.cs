using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries
{
    public class LanguageQuery:Query
    {
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string NativeName { get; set; }
        public string Flag { get; set; }

    }
}
