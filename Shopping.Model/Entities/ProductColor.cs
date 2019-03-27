using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{

    public class ProductColor : BaseEntity
    {
        public ProductColor()
        {

        }
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public string ColorId { get; set; }
        public Color Color { get; set; }
    }
}