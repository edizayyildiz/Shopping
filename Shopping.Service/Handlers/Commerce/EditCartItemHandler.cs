using AutoMapper;
using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class EditCartItemHandler : CommandHandler<Commands.EditCartItem>
    {
        private readonly IRepository<CartItem> cartItemRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditCartItemHandler(IUnitOfWork unitOfWork, IRepository<CartItem> cartItemRepository)
        {
            this.unitOfWork = unitOfWork;
            this.cartItemRepository = cartItemRepository;
        }

        public override async Task<dynamic> HandleAsync(Commands.EditCartItem command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.ProductId))
            {
                result = new Result(false, command.ProductId, "Ürün alanı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrEmpty(command.CartId))
            {
                result = new Result(false, command.CartId, "Sepet gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Quantity <= 0)
            {
                result = new Result(false, command.Quantity, "Adet giriniz.", true, null);
                return await Task.FromResult(result);
            }

            // map command to the model
            var model = Mapper.Map<CartItem>(command);

            // mark the model to update
            cartItemRepository.Update(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            result = new Result(true, model.Id, "Ürün başarıyla güncellendi.", true, 1);
            // return the result
            return await Task.FromResult(result);
        }
    }
}
