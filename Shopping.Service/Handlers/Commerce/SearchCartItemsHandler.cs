using AutoMapper;
using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries.Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class SearchCartItemsHandler : CommandHandler<Commands.SearchCartItems>
    {
        private readonly IRepository<CartItem> cartItemRepository;
        public SearchCartItemsHandler(IRepository<CartItem> cartItemRepository)
        {
            this.cartItemRepository = cartItemRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchCartItems command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;
            // define the sort expression
            Expression<Func<CartItem, object>> orderby;
            switch (command.SortField)
            {
                case "quantity":
                    orderby = o => o.Quantity;
                    break;
                case "productName":
                    orderby = o => o.Product.Name;
                    break;
                case "unitPrice":
                    orderby = o => o.UnitPrice;
                    break;
                default:
                    orderby = o => o.UpdatedAt;
                    break;
            }

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<CartItem, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (command.Quantity != 0 ? w.Quantity == command.Quantity : true)
                && (command.ProductId != null ? w.ProductId == command.ProductId : true)
                && (command.CartId != "" ? w.CartId == command.CartId : true);
            }
            else
            {
                where = w => (!string.IsNullOrEmpty(command.Product.Name) ? w.Product.Name.Contains(command.Product.Name) : true);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = cartItemRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc, "Country", "Districts")
                .Select(x => Mapper.Map<CartItemQuery>(x)).ToList();
                result = new Result(true, value, $"Bulunan {totalRecordCount} ürünün {command.PageNumber}. sayfasındaki kayıtları.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = cartItemRepository.GetMany(where, orderby, desc, "Country", "Districts")
                .Select(x => Mapper.Map<CartItemQuery>(x)).ToList();
                // return the query
                result = new Result(true, value, $"{value.Count()} adet ürün bulundu.", false, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
