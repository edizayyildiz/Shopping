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
    public class SearchStoreBrandsHandler : CommandHandler<Commands.SearchStoreBrands>
    {
        private readonly IRepository<StoreBrand> storeBrandRepository;
        public SearchStoreBrandsHandler(IRepository<StoreBrand> storeBrandRepository)
        {
            this.storeBrandRepository = storeBrandRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchStoreBrands command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;

            // define the sort expression
            Expression<Func<StoreBrand, object>> orderby;
            switch (command.SortField)
            {
                case "storeId":
                    orderby = o => o.StoreId;
                    break;
                case "brandId":
                    orderby = o => o.BrandId;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<StoreBrand, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.StoreId) ? w.StoreId.Contains(command.StoreId) : true)
                && (command.BrandId != null ? w.BrandId == command.BrandId : true);

            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.StoreId) ? w.StoreId.Contains(command.StoreId) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = storeBrandRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc)
                .Select(x => Mapper.Map<StoreBrandQuery>(x)).ToList();
                // return the paged query
                result = new Result(true, value, $"Bulunan {totalRecordCount} mağazanın markaların {command.PageNumber}. sayfasındaki kayıtlar.", false, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = storeBrandRepository.GetMany(where, orderby, desc)
                .Select(x => Mapper.Map<StoreBrandQuery>(x)).ToList();
                // return the query
                result = new Result(true, value, $"{value.Count()} adet mağazanın markası bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
