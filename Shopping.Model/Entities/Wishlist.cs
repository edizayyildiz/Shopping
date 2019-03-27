using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class Wishlist:BaseEntity
    {
        public string UserName { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
