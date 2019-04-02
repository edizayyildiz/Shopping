using AutoMapper;
using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class EditCartHandler : CommandHandler<Commands.EditCart>
    {
        private readonly IRepository<Cart> cartRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditCartHandler(IUnitOfWork unitOfWork, IRepository<Cart> cartRepository)
        {
            this.unitOfWork = unitOfWork;
            this.cartRepository = cartRepository;
        }

        public override async Task<dynamic> HandleAsync(Commands.EditCart command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                result = new Result(false, command.Id, "Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }

            // map command to the model
            var model = Mapper.Map<Cart>(command);

            // mark the model to update
            cartRepository.Update(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            result = new Result(true, model.Id, "Ürün başarıyla güncellendi.", true, 1);
            // return the result
            return await Task.FromResult(result);
        }
    }
}
