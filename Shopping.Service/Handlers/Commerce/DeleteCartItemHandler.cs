using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class DeleteCartItemHandler : CommandHandler<Commands.DeleteCartItem>
    {
        private readonly IRepository<CartItem> cartItemRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteCartItemHandler(IUnitOfWork unitOfWork, IRepository<CartItem> cartItemRepository)
        {
            this.unitOfWork = unitOfWork;
            this.cartItemRepository = cartItemRepository;
        }

        public override async Task<dynamic> HandleAsync(Commands.DeleteCartItem command)
        {
            Result result;
            // get the model from database
            var model = cartItemRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                return new Result(true, null, "Ürün bulunamadı.", true, 0);

            }
            // delete the model
            cartItemRepository.Delete(model);
            unitOfWork.SaveChanges();


            // return the query result

            result = new Result(true, command.Id, "Ürün eklendi.", false, 1);

            return await Task.FromResult(result);
        }
    }
}
