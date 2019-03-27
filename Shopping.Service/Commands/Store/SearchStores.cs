using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Store, Authorities.Read, "Mağaza arar.")]
    public class SearchStores : Command, ISearchCommand
    {
        public SearchStores()
        {
            IsAdvancedSearch = false;
            SortField = "createdAt";
            SortOrder = "desc";
            IsPagedSearch = false;
            PageNumber = 1;
            PageSize = 10;
        }

        public string Name { get; set; }
        public string Slug { get; set; }
        public string Owner { get; set; }
        public string Logo { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string BrandId { get; set; }
        public bool? IsActive { get; set; }
        public bool IsAdvancedSearch { get; set; }
        public string SortOrder { get; set; }
        public string SortField { get; set; }
        public bool IsPagedSearch { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
