using Shopping.Model.Entities;
using Shopping.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries
{
    public class OrderQuery:Query
    {
   
        public string UserName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DemandDate { get; set; }
        public string OrderCode { get; set; }
        public int Quantity { get; set; }
        public Address DeliveryAddress { get; set; }
        public Address InvoiceAddress { get; set; }
        public string DeliveryAddressId { get; set; }
        public string InvoiceAddressId { get; set; }
        public int Total { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
        //public OrderItem OrderItem { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
