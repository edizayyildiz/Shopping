using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries
{
    public class OrderItemQuery:Query
    {
       
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get { return Product.NewPrice * Quantity; } }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }
        public int AvailabilityCount { get; set; }
        public string CategoryId { get; set; }
        public ProductCategory Category { get; set; }
        public string BrandId { get; set; }
        public Brand Brand { get; set; }
        public string StoreId { get; set; }
        public Shopping.Model.Entities.Store Store { get; set; }
        public Shipper Shipper { get; set; }
        public string ShipperId { get; set; }




    }
}
