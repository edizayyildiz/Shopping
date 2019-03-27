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
    public class SearchProductColorsHandler : CommandHandler<Commands.SearchProductColors>
    {
        private readonly IRepository<ProductColor> productcolorRepository;
        public SearchProductColorsHandler(IRepository<ProductColor> productcolorRepository)
        {
            this.productcolorRepository = productcolorRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchProductColors command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<ProductColor, object>> orderby;
            switch (command.SortField)
            {
                case "productId":
                    orderby = o => o.ProductId;
                    break;
                case "isActive":
                    orderby = o => o.IsActive;
                    break;
                case "colorId":
                    orderby = o => o.ColorId;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<ProductColor, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.ProductId) ? w.ProductId.Contains(command.ProductId) : true)
                && (command.IsActive != null ? w.IsActive == command.IsActive : true)
                && (command.ColorId != null ? w.ColorId == command.ColorId : true);
            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.ProductId) ? w.ProductId.Contains(command.ProductId) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {              

                var value2 = productcolorRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc);
                var value = value2.Select(x => Mapper.Map<ProductQuery>(x)).ToList();
                // return the paged query
                result = new Result(true, value, $"Bulunan {totalRecordCount} ürün renginin {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);

            }
            else
            {              
                
                var value2 = productcolorRepository.GetMany(where, orderby, desc);
                var value = value2.Select(x => Mapper.Map<ProductQuery>(x)).ToList();
                // return the query
                result = new Result(true, value, $"{value.Count()} adet ürün rengi bulundu.", true, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
