using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteProductCategoryHandler : CommandHandler<Commands.DeleteProductCategory>
    {
        private readonly IRepository<ProductCategory> productcategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteProductCategoryHandler(IUnitOfWork unitOfWork, IRepository<ProductCategory> productcategoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productcategoryRepository = productcategoryRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteProductCategory command)
        {
            Result result;
            // get the model from database
            var model = productcategoryRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                result= new Result(false, command.Id, "Ürün kategorisi bulunamadı.", true, 0);
                // return the not found result
                return await Task.FromResult(result);
            }
            // delete the model
            productcategoryRepository.Delete(model);
            unitOfWork.SaveChanges();

            result = new Result(true,command.Id, "1 adet ürün kategorisi silindi.", false, 1);
            // return the query result
            return await Task.FromResult(result);
        }
    }
}
