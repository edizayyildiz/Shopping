using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
   public class Language:BaseEntity
   {
        public string Name { get; set; }
        public string NativeName { get; set; }
        public string Flag { get; set; }
    }
}
