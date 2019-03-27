using Shopping.Model.Entities;
using Shopping.Model.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Read, "Ürün resimlerini arar.")]
    public class SearchProductPhotos : Command, ISearchCommand
    {
        public SearchProductPhotos()
        {
            IsAdvancedSearch = false;
            SortField = "createdAt";
            SortOrder = "desc";
            IsPagedSearch = false;
            PageNumber = 1;
            PageSize = 10;
        }
        public string Medium { get; set; }
        public string Small { get; set; }
        public string Large { get; set; }
        public bool? IsActive { get; set; }
        public string Alt { get; set; }
        public string ProductId { get; set; }
        public bool IsAdvancedSearch { get; set; }
        public string SortOrder { get; set; }
        public string SortField { get; set; }
        public bool IsPagedSearch { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }



    }
}
