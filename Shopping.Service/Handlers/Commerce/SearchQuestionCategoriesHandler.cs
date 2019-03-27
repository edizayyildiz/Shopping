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
    public class SearchQuestionCategoriesHandler : CommandHandler<Commands.SearchQuestionCategory>
    {
        private readonly IRepository<QuestionCategory> questionCategoryRepository;
        public SearchQuestionCategoriesHandler(IRepository<QuestionCategory> questionCategoryRepository)
        {
            this.questionCategoryRepository = questionCategoryRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchQuestionCategory command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<QuestionCategory, object>> orderby;
            switch (command.SortField)
            {
                case "name":
                    orderby = o => o.Name;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<QuestionCategory, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true);


            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = questionCategoryRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc, "ProductQuestion")
                .Select(x => Mapper.Map<QuestionCategoryQuery>(x)).ToList();
                // return the paged query
                result= new Result(true, value, $"Bulunan {totalRecordCount} soru kategorisinin {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = questionCategoryRepository.GetMany(where, orderby, desc, "ProductQuestion")
                .Select(x => Mapper.Map<QuestionCategoryQuery>(x)).ToList();
                // return the query
                result= new Result(true, value, $"{value.Count()} adet soru kategorisi bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
