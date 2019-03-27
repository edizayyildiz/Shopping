using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class AddOrderItemHandler : CommandHandler<Commands.AddOrderItem>
    {
        private readonly IRepository<OrderItem> orderItemRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AddOrderItemHandler(IUnitOfWork unitOfWork, IRepository<OrderItem> orderItemRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.unitOfWork = unitOfWork;
            this.orderItemRepository = orderItemRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddOrderItem command)
        {
            // validate the command
            Result result;
            if (string.IsNullOrWhiteSpace(command.OrderId))
            {
                result= new Result(false, command.OrderId, "Sipariş ID gereklidir.", true, null);
                return await Task.FromResult(result);

            }
            if (string.IsNullOrWhiteSpace(command.ProductId))
            {
                result= new Result(false, command.OrderId, "Ürün ID gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            // map command to the model
            var model = Mapper.Map<OrderItem>(command);
            
            //model.UserName = "emir"; //httpContextAccessor.HttpContext.Session.Id; // Session Id

            // mark the model to insert
            orderItemRepository.Insert(model);

            // save changes to database
            try
            {
                await unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result= new Result(true, model.Id, ex.Message, true, 0);
                return await Task.FromResult(result);
            }

            // return the result
            result= new Result(true,model.Id,"Sipariş öğesi başarıyla eklendi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
