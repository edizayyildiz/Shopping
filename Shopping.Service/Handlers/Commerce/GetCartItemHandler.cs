using AutoMapper;
using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries.Commerce;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class GetCartItemHandler : CommandHandler<Commands.GetCartItem>
    {
        private readonly IRepository<CartItem> cartItemRepository;
        public GetCartItemHandler(IRepository<CartItem> cartItemRepository)
        {
            this.cartItemRepository = cartItemRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetCartItem command)
        {
            Result result;
            // get the model from database
            var model = cartItemRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, command.Id, "Ürün bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<CartItemQuery>(model);

            // return the query result           

            result = new Result(true, value, "Ürün bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
