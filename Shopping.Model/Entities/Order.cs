using Shopping.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shopping.Model.Entities
{
    public class Order : BaseEntity
    {
        public Order(){
            OrderItems = new HashSet<OrderItem>();
            Coupons = new HashSet<Coupon>();
        }

        public string UserName { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DemandDate { get; set; }

        public string OrderCode { get; set; }



        public Address DeliveryAddress { get; set; }
        public string DeliveryAddressId { get; set; }


        public Address InvoiceAddress { get; set; }
        public string InvoiceAddressId { get; set; }


        public Store Store { get; set; }
        public string StoreId { get; set; }



        public OrderStatus OrderStatus { get; set; }

        public int Quantity { get { return OrderItems.Sum(s => s.Quantity); } }

        public decimal Total { get { return OrderItems.Sum(s => s.Total); } }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public virtual ICollection<Coupon> Coupons { get; set; }
    }
}
