using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteOrderItemHandler : CommandHandler<Commands.DeleteOrderItem>
    {
        private readonly IRepository<OrderItem> orderItemRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteOrderItemHandler(IUnitOfWork unitOfWork, IRepository<OrderItem> orderItemRepository)
        {
            this.unitOfWork = unitOfWork;
            this.orderItemRepository = orderItemRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteOrderItem command)
        {
            Result result;
            // get the model from database
            var model = orderItemRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result= new Result(false, command.Id, "Sipariş Öğesi bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // delete the model
            orderItemRepository.Delete(model);
            unitOfWork.SaveChanges();


            // return the query result
            result= new Result(true,command.Id, "1 adet sipariş öğesi silindi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
