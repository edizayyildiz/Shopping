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
    public class GetCartHandler : CommandHandler<Commands.GetCart>
    {
        private readonly IRepository<Cart> cartRepository;
        public GetCartHandler(IRepository<Cart> cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetCart command)
        {
            Result result;
            // get the model from database
            var model = cartRepository.Get(w => w.UserName == command.UserName, "CartItems", "CartItems.Product");

            // if nothing found
            if (model == null)
            {
                var c = new Cart();
                cartRepository.Insert(c);
                // return the not found result
                var v = Mapper.Map<CartQuery>(c);
                result = new Result(true, v, "Boş sepet döndü.", false, null);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<CartQuery>(model);

            // return the query result           

            result = new Result(true, value, "Sepet bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
