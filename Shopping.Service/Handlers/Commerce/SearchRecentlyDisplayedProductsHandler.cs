using AutoMapper;
using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class SearchRecentlyDisplayedProductsHandler: CommandHandler<Commands.SearchRecentlyDisplayedProducts>
    {
        private readonly IRepository<RecentlyDisplayedProduct> repository;
        public SearchRecentlyDisplayedProductsHandler(IRepository<RecentlyDisplayedProduct> repository)
        {
            this.repository = repository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchRecentlyDisplayedProducts command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;

            // define the sort expression
            Expression<Func<RecentlyDisplayedProduct, object>> orderby;
            switch (command.SortField)
            {
                case "username":
                    orderby = o => o.UserName;
                    break;
                case "displaydate":
                    orderby = o => o.DisplayDate;
                    break;
                case "productId":
                    orderby = o => o.ProductId;
                    break;
                default:
                    orderby = o => o.CreatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<RecentlyDisplayedProduct, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (!string.IsNullOrEmpty(command.UserName) ? w.UserName.Contains(command.UserName) : true)
                &&  (command.DisplayDate != null ? w.DisplayDate == command.DisplayDate : true)
                && (command.ProductId != null ? w.ProductId == command.ProductId : true);
            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.UserName) ? w.UserName.Contains(command.UserName) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {

                var value = repository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc)
                .Select(x => Mapper.Map<RecentlyDisplayedProduct>(x)).ToList();
                // return the paged query
                result = new Result(true, value, $"Bulunan {totalRecordCount} son görüntülenmenin {command.PageNumber}. sayfasındaki kayıtları.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = repository.GetMany(where, orderby, desc)
                .Select(x => Mapper.Map<RecentlyDisplayedProduct>(x)).ToList();
                // return the query
                result = new Result(true, value, $"{value.Count()} adet son görüntülenme bulundu.", true, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
