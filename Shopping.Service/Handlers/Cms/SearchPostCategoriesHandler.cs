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
    public class SearchPostCategoriesHandler : CommandHandler<Commands.SearchPostCategories>
    {
        private readonly IRepository<PostCategory> postcategoryRepository;
        public SearchPostCategoriesHandler(IRepository<PostCategory> postcategoryRepository)
        {
            this.postcategoryRepository = postcategoryRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchPostCategories command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;

            // define the sort expression
            Expression<Func<PostCategory, object>> orderby;
            switch (command.SortField)
            {
                case "name":
                    orderby = o => o.Name;
                    break;
                case "isActive":
                    orderby = o => o.IsActive;
                    break;
                case "slug":
                    orderby = o => o.Slug;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<PostCategory, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true)
                && (command.IsActive != null ? w.IsActive == command.IsActive : true)
                && (command.Slug != null ? w.Slug == command.Slug : true);


            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = postcategoryRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc)
                .Select(x => Mapper.Map<PostCategoryQuery>(x)).ToList();
                // return the paged query
                result= new Result(true, value,  $"Bulunan {totalRecordCount} yazı kategorisinin {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = postcategoryRepository.GetMany(where, orderby, desc)
                .Select(x => Mapper.Map<PostCategoryQuery>(x)).ToList();
                // return the query
                result= new Result(true, value, $"{value.Count()} adet yazı kategorisi bulundu.", true, value.Count());
                return await Task.FromResult(result);

            }
        }
    }
}
