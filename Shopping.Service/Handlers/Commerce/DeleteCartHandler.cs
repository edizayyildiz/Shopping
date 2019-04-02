using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class DeleteCartHandler : CommandHandler<Commands.DeleteCart>
    {
        private readonly IRepository<Cart> cartRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteCartHandler(IUnitOfWork unitOfWork, IRepository<Cart> cartRepository)
        {
            this.unitOfWork = unitOfWork;
            this.cartRepository = cartRepository;
        }

        public override async Task<dynamic> HandleAsync(Commands.DeleteCart command)
        {
            Result result;
            // get the model from database
            var model = cartRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                return new Result(true, null, "Sepet bulunamadı.", true, 0);

            }
            // delete the model
            cartRepository.Delete(model);
            unitOfWork.SaveChanges();


            // return the query result

            result = new Result(true, command.Id, "Sepet oluşturuldu.", false, 1);

            return await Task.FromResult(result);
        }
    }
}
