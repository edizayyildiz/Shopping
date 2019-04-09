using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Read, "Geri bildirim arar.")]
    public  class SearchFeedbacks:Command,ISearchCommand
    {
        public SearchFeedbacks() {

            IsAdvancedSearch = false;
            SortField = "createdAt";
            SortOrder = "desc";
            IsPagedSearch = false;
            PageNumber = 1;
            PageSize = 10;
        }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }
        public bool IsAdvancedSearch { get; set; }
        public string SortField { get; set; }
        public string SortOrder { get; set; }
        public bool IsPagedSearch { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
