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
    public class AddOrderHandler : CommandHandler<Commands.AddOrder>
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AddOrderHandler(IUnitOfWork unitOfWork, IRepository<Order> orderRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.unitOfWork = unitOfWork;
            this.orderRepository = orderRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddOrder command)
        {
            // validate the command
            Result result;
            if (string.IsNullOrWhiteSpace(command.UserName))
            {
                result = new Result(false, command.UserName, "Kullanıcı Adı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            // map command to the model
            var model = Mapper.Map<Order>(command);

            model.UserName = "emir"; //httpContextAccessor.HttpContext.Session.Id; // Session Id

            // mark the model to insert
            orderRepository.Insert(model);

            // save changes to database
            try
            {
                unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                result = new Result(true, model.Id, ex.Message, true, ex.StackTrace);
                return await Task.FromResult(result);
            }
            // return the result
            result = new Result(true, model.Id, "Sipariş başarıyla eklendi.", true, 1);
            return await Task.FromResult(result);           
        }
    }
}
