using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Cms, Authorities.Read, "Reklam arar.")]
    public class SearchAdvertisements : Command, ISearchCommand
    {
        public SearchAdvertisements()
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
        public string SubTitle { get; set; }
        public string Html { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public bool IsAdvancedSearch { get; set; }
        public string SortField { get; set; }
        public string SortOrder { get; set; }
        public bool IsPagedSearch { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

    }
}
