using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Read, "Kupon arar.")]
    public class SearchCoupons : Command
    {
        public SearchCoupons()
        {
            IsAdvancedSearch = false;
            SortField = "createdAt";
            SortOrder = "desc";
            IsPagedSearch = false;
            PageNumber = 1;
            PageSize = 10;
        }

        public string CouponNo { get; set; }
        public int CouponNumber { get; set; }
        public string Name { get; set; }
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StoreId { get; set; }
        public Store Store { get; set; }
        public decimal MinTotalPrice { get; set; }
        public decimal Discount { get; set; }
        public string Conditions { get; set; }
        public bool IsAdvancedSearch { get; set; }
        public string SortOrder { get; set; }
        public string SortField { get; set; }
        public bool IsPagedSearch { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
