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
    public class SearchProductPhotosHandler : CommandHandler<Commands.SearchProductPhotos>
    {
        private readonly IRepository<ProductPhoto> productphotoRepository;
        public SearchProductPhotosHandler(IRepository<ProductPhoto> productphotoRepository)
        {
            this.productphotoRepository = productphotoRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchProductPhotos command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<ProductPhoto, object>> orderby;
            switch (command.SortField)
            {
                case "medium":
                    orderby = o => o.Medium;
                    break;
                case "small":
                    orderby = o => o.Small;
                    break;
                case "large":
                    orderby = o => o.Large;
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
            Expression<Func<ProductPhoto, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.Medium) ? w.Medium.Contains(command.Medium) : true)
                && (command.Small != null ? w.Small == command.Small : true)
                && (command.Large != null ? w.Large == command.Large : true)
                && (command.IsActive != null ? w.IsActive == command.IsActive : true);
                                             
            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Medium) ? w.Medium.Contains(command.Medium) : true)
                && (command.Small != null ? w.Small == command.Small : true)
                && (command.Large != null ? w.Large == command.Large : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {              
                
                var value2 = productphotoRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc);
                var value = value2.Select(x => Mapper.Map<ProductQuery>(x)).ToList();
                // return the paged query
                result = new Result(true, value, $"Bulunan {totalRecordCount} ürün resminin {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);


            }
            else
            {
                
                var value2 = productphotoRepository.GetMany(where, orderby, desc);
                var value = value2.Select(x => Mapper.Map<ProductQuery>(x)).ToList();
                // return the query
                result = new Result(true, value, $"{value.Count()}adet ürün resmi bulundu.", true, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
