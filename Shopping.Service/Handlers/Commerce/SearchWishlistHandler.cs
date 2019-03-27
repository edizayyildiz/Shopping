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
    public class SearchWishlistHandler : CommandHandler<Commands.SearchWishlists>
    {
        private readonly IRepository<Wishlist> wishlistRepository;
        public SearchWishlistHandler(IRepository<Wishlist> wishlistRepository)
        {
            this.wishlistRepository = wishlistRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchWishlists command)
        {
            // define pagination variables
            int skip = command.PageSize * (command.PageNumber - 1);
            int take = command.PageSize;
            Result result;

            // define the sort expression
            Expression<Func<Wishlist, object>> orderby;
            switch (command.SortField)
            {
                case "userName":
                    orderby = o => o.UserName;
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
            string userName = "emir";
            Expression<Func<Wishlist, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (w.UserName.Contains(userName))
                && (command.ProductId != null ? w.ProductId == command.ProductId : true);

            }
            else
            {
                where = w => w.UserName.Contains(userName);
            }

            // select the results by doing filtering, sorting and optionally paging, and map them
            if (command.IsPagedSearch)
            {
                var value = wishlistRepository.GetManyPaged(skip, take, out int totalRecordCount, where, orderby, desc, "Product", "Product.Images")
                .Select(x => Mapper.Map<WishlistQuery>(x)).ToList();
                // return the paged query
                result = new Result(true, value, $"Bulunan {totalRecordCount} dilek listesi {command.PageNumber}. sayfasındaki kayıtlar.", true, totalRecordCount);
                return await Task.FromResult(result);
            }
            else
            {
                var value = wishlistRepository.GetMany(where, orderby, desc, "Product", "Product.Images")
                .Select(x => Mapper.Map<WishlistQuery>(x)).ToList();

                // return the query

                result = new Result(true, value,  $"{value.Count()} adet dilek bulundu.", true, value.Count());
                return await Task.FromResult(result);
            }
        }
    }
}
