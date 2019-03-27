using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteProductHandler : CommandHandler<Commands.DeleteProduct>
    {
        private readonly IRepository<Product> productRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteProductHandler(IUnitOfWork unitOfWork, IRepository<Product> productRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = productRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteProduct command)
        {
            Result result;
            // get the model from database
            var model = productRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, command.Id, "Ürün bulunamadı.", false, null);
                return await Task.FromResult(result);
            }
            // delete the model
            productRepository.Delete(model);
            unitOfWork.SaveChanges();

            // return the query result
            result = new Result(true, command.Id, "1 adet ürün silindi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
