using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class CartItem : BaseEntity
    {
        public string ProductId { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get { return Product.NewPrice; } }
        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
