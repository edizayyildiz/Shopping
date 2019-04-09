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
            var model = cartRepository.Get(command.UserName);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, command.UserName, "Sepet bulunamadı.", true, null);
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
