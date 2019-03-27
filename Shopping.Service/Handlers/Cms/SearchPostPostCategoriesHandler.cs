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
    public class SearchPostPostCategoriesHandler : CommandHandler<Commands.SearchPostPostCategories>
    {
        private readonly IRepository<PostPostCategory> postpostcategoryRepository;
        public SearchPostPostCategoriesHandler(IRepository<PostPostCategory> postpostcategoryRepository)
        {
            this.postpostcategoryRepository = postpostcategoryRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchPostPostCategories command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;

            // define the sort expression
            Expression<Func<PostPostCategory, object>> orderby;
            switch (command.SortField)
            {
                case "postId":
                    orderby = o => o.PostId;
                    break;
                case "postCategoryId":
                    orderby = o => o.PostCategoryId;
                    break;
                case "isActive":
                    orderby = o => o.IsActive;
                    break;

                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<PostPostCategory, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.PostId) ? w.PostId.Contains(command.PostId) : true)
                && (command.PostCategoryId != null ? w.PostCategoryId == command.PostCategoryId : true)
                && (command.IsActive != null ? w.IsActive == command.IsActive : true);


            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.PostId) ? w.PostId.Contains(command.PostId) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = postpostcategoryRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc)
                .Select(x => Mapper.Map<PostPostCategoryQuery>(x)).ToList();
                // return the paged query
                result = new Result(true, value, $"Bulunan {totalRecordCount} yazı ile yazı kategorisi arasındaki ilişki {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = postpostcategoryRepository.GetMany(where, orderby, desc)
                .Select(x => Mapper.Map<PostPostCategoryQuery>(x)).ToList();
                // return the query
                result = new Result(true, value, $"{value.Count()} adet yazı ile yazı kategorisi arasındaki ilişki bulundu.", true, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
