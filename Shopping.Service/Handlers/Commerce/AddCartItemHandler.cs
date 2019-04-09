using AutoMapper;
using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class AddCartItemHandler : CommandHandler<Commands.AddCartItem>
    {
        private readonly IRepository<CartItem> brandRepository;
        private readonly IUnitOfWork unitOfWork;
        public AddCartItemHandler(IUnitOfWork unitOfWork, IRepository<CartItem> brandRepository)
        {
            this.unitOfWork = unitOfWork;
            this.brandRepository = brandRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddCartItem command)
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

            // mark the model to insert
            brandRepository.Insert(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();


            result = new Result(true, model.Id, "Ürün başarıyla eklendi.", true, 1);
            // return the result
            return await Task.FromResult(result);
        }
    }
}
