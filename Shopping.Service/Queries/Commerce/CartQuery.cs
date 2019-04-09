using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping.Service.Queries.Commerce
{
    public class CartQuery : Query
    {
        public virtual ICollection<CartItem> CartItems { get; set; }
        public string UserName { get; set; }
        public decimal? CartTotal { get { return CartItems.Sum(s => s.Quantity * s.UnitPrice); } }
    }
}
