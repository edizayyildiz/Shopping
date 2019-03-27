using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Model.Entities
{
    public class ProductCategory : BaseEntity
    {
        public ProductCategory()
        {
            Childs = new HashSet<ProductCategory>();
            Products = new HashSet<Product>();
            OrderItems = new HashSet<OrderItem>();
        }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public bool HasSubCategory { get { return Childs.Count > 0; } }
        public string ParentId { get; set; }
        public ProductCategory Parent { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<ProductCategory> Childs { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
