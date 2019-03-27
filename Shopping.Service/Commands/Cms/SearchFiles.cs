using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Read, "Dosya arar.")]
    public class SearchFiles : Command, ISearchCommand
    {
        public SearchFiles()
        {
            IsAdvancedSearch = false;
            SortField = "createdAt";
            SortOrder = "desc";
            IsPagedSearch = false;
            PageNumber = 1;
            PageSize = 10;
        }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Alt { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public string Extension { get; set; }
        public bool IsAdvancedSearch { get; set; }
        public string SortField { get; set; }
        public string SortOrder { get; set; }
        public bool IsPagedSearch { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool? IsActive { get; set; }


    }
}
