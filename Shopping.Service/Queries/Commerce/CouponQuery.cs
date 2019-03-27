using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Queries
{
    public class CouponQuery:Query
    {   
        public string CouponNo { get; set; }
        public int CouponNumber { get; set; }
        public string Name { get; set; }
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StoreId { get; set; }
        public Shopping.Model.Entities.Store Store  { get; set; }
        public decimal MinTotalPrice { get; set; }
        public decimal Discount { get; set; }
        public string Conditions { get; set; }

    }
}
