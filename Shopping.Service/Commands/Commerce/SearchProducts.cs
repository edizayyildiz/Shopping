using Shopping.Model.Entities;
using Shopping.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Read, "Ürünleri arar.")]
    public class SearchProducts : Command, ISearchCommand
    {
        public SearchProducts()
        {
            IsAdvancedSearch = false;
            SortField = "name";
            SortOrder = "desc";
            IsPagedSearch = false;
            PageNumber = 1;
            PageSize = 10;
        }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string BrandId { get; set; }
        public string StoreId { get; set; }
        public bool? IsFeatured { get; set; }
        public bool? IsOnSale { get; set; }
        public bool? IsNew { get; set; }
        public bool IsAdvancedSearch { get; set; }
        public string SortOrder { get; set; }
        public string SortField { get; set; }
        public bool IsPagedSearch { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Condition? Condition { get; set; }
        public Store Store { get; set; }
    }
}
