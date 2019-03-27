using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class Shipper:BaseEntity
    {
        public Shipper()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        public string Name { get; set; }
        public string Url { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
