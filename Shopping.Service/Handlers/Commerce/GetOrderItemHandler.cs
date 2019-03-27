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
    public class GetOrderItemHandler : CommandHandler<Commands.GetOrderItem>
    {
        private readonly IRepository<OrderItem> orderItemRepository;
        public GetOrderItemHandler(IRepository<OrderItem> orderItemRepository)
        {
            this.orderItemRepository = orderItemRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetOrderItem command)
        {
            Result result;
            // get the model from database
            var model = orderItemRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, command.Id, "Sipariş öğesi bulunamadı.", false, null);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<OrderItemQuery>(model);

            // return the query result
            result = new Result(true, command.Id, "1 adet sipariş öğesi bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
