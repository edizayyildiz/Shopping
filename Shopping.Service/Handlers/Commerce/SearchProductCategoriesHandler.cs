using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries.Commerce;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class SearchProductCategoriesHandler : CommandHandler<Commands.SearchProductCategories>
    {
        private readonly IRepository<ProductCategory> productcategoryRepository;
        public SearchProductCategoriesHandler(IRepository<ProductCategory> productcategoryRepository)
        {
            this.productcategoryRepository = productcategoryRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchProductCategories command)
        {
            Result result;
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;

            // define the sort expression
            Expression<Func<ProductCategory, object>> orderby;
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
            Expression<Func<ProductCategory, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true)
                && (command.IsActive != null ? w.IsActive == command.IsActive : true)
                && (command.Slug != null ? w.Slug == command.Slug : true)
                && (command.ParentId != null ? w.ParentId == command.ParentId : true);


            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = productcategoryRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc)
                .Select(x => Mapper.Map<ProductCategoryQuery>(x)).ToList();
                // return the paged query
                result = new Result(true, value, $"Bulunan {totalRecordCount} ürün kategorisinin {command.PageNumber}. sayfasındaki kayıtlar.", false, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = productcategoryRepository.GetMany(where, orderby, desc)
                .Select(x => Mapper.Map<ProductCategoryQuery>(x)).ToList();
                // return the query
                result = new Result(true, value, $"{value.Count()} adet ürün kategorisi bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
