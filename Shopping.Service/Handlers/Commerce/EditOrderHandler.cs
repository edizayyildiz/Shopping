using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditOrderHandler : CommandHandler<Commands.EditOrder>
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditOrderHandler(IUnitOfWork unitOfWork, IRepository<Order> orderRepository)
        {
            this.unitOfWork = unitOfWork;
            this.orderRepository = orderRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditOrder command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                result = new Result(false, command.Id, "Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.UserName))
            {
                result = new Result(false, command.UserName, "Kullanıcı Adı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.UserName.Length > 200)
            {
                result = new Result(false, command.UserName.Length, "Kullanıcı Adı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            // map command to the model
            var model = Mapper.Map<Order>(command);

            // mark the model to update
            orderRepository.Update(model);

            // save changes to database
            unitOfWork.SaveChanges();

            // return the result
            result = new Result(true, model.Id, "Sipariş başarıyla güncellendi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
