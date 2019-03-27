using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{

    [Describe(CommandType.Cms, Authorities.Read, "Görüşleri arar.")]
    public class SearchReviews : Command, ISearchCommand
    {
        public SearchReviews()
        {
            IsAdvancedSearch = false;
            SortField = "createdAt";
            SortOrder = "desc";
            IsPagedSearch = false;
            PageNumber = 1;
            PageSize = 10;
        }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string Email { get; set; }
        public string ProductId { get; set; }
        public bool IsAdvancedSearch { get; set; }
        public string SortOrder { get; set; }
        public string SortField { get; set; }
        public bool IsPagedSearch { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
