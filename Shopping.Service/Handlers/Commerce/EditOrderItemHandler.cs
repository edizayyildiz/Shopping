using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditOrderItemHandler : CommandHandler<Commands.EditOrderItem>
    {
        private readonly IRepository<OrderItem> orderItemRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditOrderItemHandler(IUnitOfWork unitOfWork, IRepository<OrderItem> orderItemRepository)
        {
            this.unitOfWork = unitOfWork;
            this.orderItemRepository = orderItemRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditOrderItem command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                result = new Result(false, command.Id, "id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.OrderId))
            {
                result = new Result(false, command.Id, "id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.ProductId))
            {
                result = new Result(false, command.ProductId, "ProductId gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            // map command to the model
            var model = Mapper.Map<OrderItem>(command);

            // mark the model to update
            orderItemRepository.Update(model);

            // save changes to database
            unitOfWork.SaveChanges();

            // return the result
            return new Result(true,model.Id,  "Sipariş öğesi başarıyla güncellendi.", false, 1);
        }
    }
}
