using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping.Model.Entities
{
    public class Cart : BaseEntity
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public string UserName { get; set; }
        public decimal CartTotal { get { return CartItems.Sum(s => s.Quantity * s.UnitPrice); } }
    }
}
