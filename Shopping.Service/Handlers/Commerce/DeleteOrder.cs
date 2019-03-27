using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteOrderHandler : CommandHandler<Commands.DeleteOrder>
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteOrderHandler(IUnitOfWork unitOfWork, IRepository<Order> orderRepository)
        {
            this.unitOfWork = unitOfWork;
            this.orderRepository = orderRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteOrder command)
        {
            Result result;
            // get the model from database
            string userName = "emir";

            IEnumerable<Order> model;
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                model = orderRepository.GetMany(w => w.UserName == userName, o => o.CreatedAt, true);
            }
            else
            {
                model = orderRepository.GetMany(w => w.UserName == userName, o => o.CreatedAt, true);
            }

            // if nothing found
            if (model == null || model.Count() == 0)
            {
                // return the not found result
                result = new Result(false, command.Id, "Sipariş bulunamadı.", false, null);
                return await Task.FromResult(result);
            }
            // delete the model
            foreach (var item in model)
            {
                orderRepository.Delete(item);
            }
            unitOfWork.SaveChanges();

            // return the query result
            result = new Result(true, command.Id, "1 adet sipariş silindi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
