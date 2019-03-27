using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class SearchProductQuestionsHandler : CommandHandler<Commands.SearchProductQuestions>
    {
        private readonly IRepository<ProductQuestion> productQuestionRepository;
        public SearchProductQuestionsHandler(IRepository<ProductQuestion> productQuestionRepository)
        {
            this.productQuestionRepository = productQuestionRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchProductQuestions command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<ProductQuestion, object>> orderby;
            switch (command.SortField)
            {
                case "productId":
                    orderby = o => o.ProductId;
                    break;
                case "questionCategoryId":
                    orderby = o => o.QuestionCategoryId;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<ProductQuestion, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.ProductId) ? w.ProductId.Contains(command.ProductId) : true)
                && (command.QuestionCategoryId != null ? w.QuestionCategoryId == command.QuestionCategoryId : true);

            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.ProductId) ? w.ProductId.Contains(command.ProductId) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = productQuestionRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc, "Product", "QuestionCategory", "Store")
                .Select(x => Mapper.Map<ProductQuestionQuery>(x)).ToList();
                // return the paged query
                result= new Result(true, value, $"Bulunan {totalRecordCount} ürün sorusunun {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = productQuestionRepository.GetMany(where, orderby, desc, "Product", "QuestionCategory", "Store")
                .Select(x => Mapper.Map<ProductQuestionQuery>(x)).ToList();
                // return the queryr
                result= new Result(true, value, $"{value.Count()} adet ürün sorusu bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
