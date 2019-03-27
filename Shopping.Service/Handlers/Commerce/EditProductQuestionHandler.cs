using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class EditProductQuestionHandler : CommandHandler<Commands.EditProductQuestion>
    {
        private readonly IRepository<ProductQuestion> productQuestionRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditProductQuestionHandler(IUnitOfWork unitOfWork, IRepository<ProductQuestion> productQuestionRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productQuestionRepository = productQuestionRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditProductQuestion command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                result = new Result(true, command.Id, "Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.ProductId))
            {
                result = new Result(true, command.ProductId, "Ürün ID gereklidir.", true, null);
                return await Task.FromResult(result);
            }

            if (string.IsNullOrWhiteSpace(command.QuestionCategoryId))
            {
                result = new Result(true, command.QuestionCategoryId, "Soru Kategori ID gereklidir.", true, null);
                return await Task.FromResult(result);
            }


            // map command to the model
            var model = Mapper.Map<ProductQuestion>(command);

            // mark the model to update
            productQuestionRepository.Update(model);

            // save changes to database
            unitOfWork.SaveChanges();

            // return the result
            result = new Result(true, model.Id, "Ürün sorusu başarıyla güncellendi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
