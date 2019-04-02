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
    public class SearchCartsHandler : CommandHandler<Commands.SearchCarts>
    {
        private readonly IRepository<Cart> cartRepository;
        public SearchCartsHandler(IRepository<Cart> cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.SearchCarts command)
        {
            // define the sort expression
            Expression<Func<Cart, object>> orderby = o => o.UpdatedAt;

            // define the sort direction
            bool desc = (command.SortOrder == "desc" ? true : false);

            // define the filter
            Expression<Func<Cart, bool>> where;
            if (command.IsAdvancedSearch)
            {
                where = w => (true);
            }
            Result result;
            if (command.UserName != "")
            {
                var value = cartRepository.GetMany(w => w.UserName == command.UserName, orderby, desc, "")
                .Select(x => Mapper.Map<CartQuery>(x)).ToList().FirstOrDefault();
                result = new Result(true, value, "Sepet getirildi.", true, 1);
                return await Task.FromResult(result);
            }
            else
            {
                result = new Result(false, null, "Sepet bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
        }
    }
}
