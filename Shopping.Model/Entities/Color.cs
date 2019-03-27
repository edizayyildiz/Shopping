using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class Color:BaseEntity
    {
        public Color()
        {
            ProductColors = new HashSet<ProductColor>();
        }

        public string Name { get; set; }
        public string Value { get; set; }

        public virtual ICollection<ProductColor> ProductColors { get; set; }
    }
}
