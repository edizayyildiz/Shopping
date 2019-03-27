using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Read, "Şehirleri arar.")]
    public class SearchCitys : Command, ISearchCommand
    {
        public SearchCitys()
        {
            IsAdvancedSearch = false;
            SortField = "createdAt";
            SortOrder = "desc";
            IsPagedSearch = false;
            PageNumber = 1;
            PageSize = 10;
        }

        public string Name { get; set; }
        public string CountryId { get; set; }
        public bool? ShowInHome { get; set; }
        public bool? IsActive { get; set; }
        public bool IsAdvancedSearch { get; set; }
        public string SortOrder { get; set; }
        public string SortField { get; set; }
        public bool IsPagedSearch { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
