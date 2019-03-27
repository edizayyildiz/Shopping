using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping.Service.Commands
{
    [Describe(CommandType.Commerce, Authorities.Read, "Ürün sorusu arar.")]
    public class SearchProductQuestions : Command, ISearchCommand
    {
        public SearchProductQuestions()
        {
            IsAdvancedSearch = false;
            SortField = "createdAt";
            SortOrder = "desc";
            IsPagedSearch = false;
            PageNumber = 1;
            PageSize = 10;
        }

        public string ProductId { get; set; }
        public Product Product { get; set; }
        public string QuestionCategoryId { get; set; }
        public QuestionCategory QuestionCategory { get; set; }
        public string StoreId { get; set; }
        public Store Store { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public DateTime ShareDate { get; set; }
        public bool IsPublic { get; set; }
        public bool IsAdvancedSearch { get; set; }
        public string SortOrder { get; set; }
        public string SortField { get; set; }
        public bool IsPagedSearch { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
