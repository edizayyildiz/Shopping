using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class ProductPhoto : BaseEntity
    {
        public string Medium { get; set; }
        public string Small { get; set; }
        public string Large { get; set; }
        public string Alt { get; set; }
        public int Position { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
