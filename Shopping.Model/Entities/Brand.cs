using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class Brand : BaseEntity
    {
        public Brand()
        {
            ShowInHome = false;
            Products = new HashSet<Product>();
            StoreBrands = new HashSet<StoreBrand>();
            OrdersItems = new HashSet<OrderItem>();
        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        public bool ShowInHome { get; set; }
        public virtual ICollection<OrderItem> OrdersItems { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<StoreBrand> StoreBrands { get; set; }
    }
}
