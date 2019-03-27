using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class GetWishlistHandler : CommandHandler<Commands.GetWishlist>
    {
        private readonly IRepository<Wishlist> wishlistRepository;
        public GetWishlistHandler(IRepository<Wishlist> wishlistRepository)
        {
            this.wishlistRepository = wishlistRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetWishlist command)
        {
            Result result;
            // get the model from database
            var model = wishlistRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                return new Result(false, command.Id, "Dilek bulunamadı.", true, null);
            }
            // map the model to query
            var value = Mapper.Map<WishlistQuery>(model);

            // return the query result
            result = new Result(true, value, "1 adet dilek bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
