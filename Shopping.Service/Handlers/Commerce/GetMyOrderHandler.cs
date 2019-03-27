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
    public class GetMyOrderHandler : CommandHandler<Commands.GetMyOrder>
    {
        private readonly IRepository<Order> myOrderRepository;
        public GetMyOrderHandler(IRepository<Order> myOrderRepository)
        {
            this.myOrderRepository = myOrderRepository;
        }
        public override  async Task<dynamic> HandleAsync(Commands.GetMyOrder command)
        {
            Result result;

            // get the model from database
            var model = myOrderRepository.Get(command.Id, "OrderItems", "OrderItems.Product", "OrderItems.Product.Images", "OrderItems.Product.Store", "DeliveryAddress", "DeliveryAddress.City", "DeliveryAddress.Country", "DeliveryAddress.District", "InvoiceAddress", "InvoiceAddress.City", "InvoiceAddress.Country", "InvoiceAddress.District");

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, command.Id, "Sipariş detayı bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<OrderQuery>(model);

            // return the query result
            result =  new Result(true, value,  "1 adet sipariş detayı bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
