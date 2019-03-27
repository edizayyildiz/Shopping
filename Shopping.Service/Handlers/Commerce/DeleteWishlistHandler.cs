using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteWishlistHandler : CommandHandler<Commands.DeleteWishlist>
    {
        private readonly IRepository<Wishlist> wishlistRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteWishlistHandler(IUnitOfWork unitOfWork, IRepository<Wishlist> wishlistRepository)
        {
            this.unitOfWork = unitOfWork;
            this.wishlistRepository = wishlistRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteWishlist command)
        {
            Result result;
            // get the model from database
            string userName = "emir";

            IEnumerable<Wishlist> model;
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                model = wishlistRepository.GetMany(w => w.UserName == userName, o => o.CreatedAt, true);
            }
            else
            {
                model = wishlistRepository.GetMany(w => w.ProductId == command.Id && w.UserName == userName, o => o.CreatedAt, true);
            }

            // if nothing found
            if (model == null || model.Count() == 0)
            {
                // return the not found result
                result= new Result( true, null, "Dilek bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // delete the model
            foreach (var item in model)
            {
                wishlistRepository.Delete(item);
            }
           await unitOfWork.SaveChangesAsync();


            // return the query result
            result= new Result( true, command.Id, "1 adet dilek silindi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
