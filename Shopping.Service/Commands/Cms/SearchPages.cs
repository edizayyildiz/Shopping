using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Read, "Sayfa arar.")]
    public class SearchPages : Command, ISearchCommand
    {
        public SearchPages()
        {
            IsAdvancedSearch = false;
            SortField = "createdAt";
            SortOrder = "desc";
            IsPagedSearch = false;
            PageNumber = 1;
            PageSize = 10;
        }
        public string Title { get; set; }
        public bool? IsActive { get; set; }
        public string Slug { get; set; }
        public bool IsAdvancedSearch { get; set; }
        public string SortField { get; set; }
        public string SortOrder { get; set; }
        public bool IsPagedSearch { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
