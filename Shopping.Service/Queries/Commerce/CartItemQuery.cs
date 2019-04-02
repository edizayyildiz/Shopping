using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries.Commerce
{
    public class CartItemQuery : Query
    {
        public string ProductId { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get { return Product.NewPrice; } }
        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
