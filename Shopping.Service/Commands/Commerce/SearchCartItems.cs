using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Read, "Sepette ki ürünü arar.")]
    public class SearchCartItems : Command, ISearchCommand
    {
        public SearchCartItems()
        {
            IsAdvancedSearch = false;
            SortField = "createdAt";
            SortOrder = "desc";
            IsPagedSearch = false;
            PageNumber = 1;
            PageSize = 10;
        }
        public string ProductId { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get { return Product.NewPrice; } }
        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }
        public bool IsAdvancedSearch { get; set; }
        public string SortOrder { get; set; }
        public string SortField { get; set; }
        public bool IsPagedSearch { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
