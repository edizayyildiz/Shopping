using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Read, "Sipariş arar.")]
    public class SearchOrders : Command, ISearchCommand
    {
        public SearchOrders()
        {
            IsAdvancedSearch = false;
            SortField = "createdAt";
            SortOrder = "desc";
            IsPagedSearch = false;
            PageNumber = 1;
            PageSize = 10;
        }

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
        public string StoreId { get; set; }
        public Store Store { get; set; }
        public bool? IsActive { get; set; }
        public bool IsAdvancedSearch { get; set; }
        public string SortOrder { get; set; }
        public string SortField { get; set; }
        public bool IsPagedSearch { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
