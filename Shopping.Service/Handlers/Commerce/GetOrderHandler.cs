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
    public class GetOrderHandler : CommandHandler<Commands.GetOrder>
    {
        private readonly IRepository<Order> orderRepository;
        public GetOrderHandler(IRepository<Order> orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetOrder command)
        {
            Result result;
            // get the model from database
            var model = orderRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, command.Id, "Sipariş bulunamadı.", false, null);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<OrderQuery>(model);

            // return the query result
            result = new Result(true, value, "1 adet sipariş bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
