using Shopping.Data;
using Shopping.Service.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Store
{
    public class SearchStoresHandler : CommandHandler<Commands.SearchStores>
    {
        private readonly IRepository<Model.Entities.Store> storeRepository;
        public SearchStoresHandler(IRepository<Model.Entities.Store> storeRepository)
        {
            this.storeRepository = storeRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchStores command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<Model.Entities.Store, object>> orderby;
            switch (command.SortField)
            {
                case "name":
                    orderby = o => o.Name;
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
            Expression<Func<Model.Entities.Store, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true)
                && (command.IsActive != null ? w.IsActive == command.IsActive : true)
                && (command.BrandId != null ? w.StoreBrands.Any(a => a.BrandId == command.BrandId) : true);
                
            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Name) ? w.Name.Contains(command.Name) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = storeRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc)
                .Select(x => Mapper.Map<StoreQuery>(x)).ToList();
                // return the paged query
                result = new Result(true, value,  $"Bulunan {totalRecordCount} mağazanın {command.PageNumber}. sayfasındaki kayıtlar.", false, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = storeRepository.GetMany(where, orderby, desc)
                .Select(x => Mapper.Map<StoreQuery>(x)).ToList();
                // return the query
                result =  new Result(true, value, $"{value.Count()} adet mağaza bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
