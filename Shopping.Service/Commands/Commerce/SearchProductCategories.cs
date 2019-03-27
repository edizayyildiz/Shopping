using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Read, "Ürün kategorilerini arar.")]
    public class SearchProductCategories : Command, ISearchCommand
    {
        public SearchProductCategories()
        {
            IsAdvancedSearch = false;
            SortField = "createdAt";
            SortOrder = "asc";
            IsPagedSearch = false;
            PageNumber = 1;
            PageSize = 10;
        }

        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string Slug { get; set; }
        public string ParentId { get; set; }
        public bool IsAdvancedSearch { get; set; }
        public string SortOrder { get; set; }
        public string SortField { get; set; }
        public bool IsPagedSearch { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
