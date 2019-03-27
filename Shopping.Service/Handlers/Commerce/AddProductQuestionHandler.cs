using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class AddProductQuestionHandler : CommandHandler<Commands.AddProductQuestion>
    {
        private readonly IRepository<ProductQuestion> productQuestionRepository;
        private readonly IUnitOfWork unitOfWork;
        public AddProductQuestionHandler(IUnitOfWork unitOfWork, IRepository<ProductQuestion> productQuestionRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productQuestionRepository = productQuestionRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddProductQuestion command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.ProductId))
            {
                result= new Result(false,command.ProductId, "Ürün ID gereklidir.", true,null);
                return await Task.FromResult(result);
            }

            if (string.IsNullOrWhiteSpace(command.QuestionCategoryId))
            {
                result= new Result(false, command.QuestionCategoryId, "Soru Kategori ID gereklidir.", true,null);
                return await Task.FromResult(result);
            }

            // map command to the model
            var model = Mapper.Map<ProductQuestion>(command);

            // mark the model to insert
            productQuestionRepository.Insert(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            // return the result
            result= new Result(true,model.Id, "Ürün sorusu başarıyla eklendi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
