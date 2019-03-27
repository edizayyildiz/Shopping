using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteProductQuestionHandler : CommandHandler<Commands.DeleteProductQuestion>
    {
        private readonly IRepository<ProductQuestion> productQuestionRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteProductQuestionHandler(IUnitOfWork unitOfWork, IRepository<ProductQuestion> productQuestionRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productQuestionRepository = productQuestionRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteProductQuestion command)
        {
            Result result;
            // get the model from database
            var model = productQuestionRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                result= new Result(false, command.Id, "Ürün sorusu bulunamadı.", true, 0);
                // return the not found result
                return await Task.FromResult(result);
            }
            // delete the model
            productQuestionRepository.Delete(model);
            unitOfWork.SaveChanges();

            result= new Result(true, command.Id,  "1 adet ürün sorusu silindi.", false, 1);
            // return the query result
            return await Task.FromResult(result); 
        }
    }
}
