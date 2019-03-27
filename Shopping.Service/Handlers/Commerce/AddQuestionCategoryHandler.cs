using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class AddQuestionCategoryHandler : CommandHandler<Commands.AddQuestionCategory>
    {
        private readonly IRepository<QuestionCategory> questionCategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public AddQuestionCategoryHandler(IUnitOfWork unitOfWork, IRepository<QuestionCategory> questionCategoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.questionCategoryRepository = questionCategoryRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddQuestionCategory command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                result= new Result(false, command.Name, "Soru kategorisi gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Name.Length > 200)
            {
                result= new Result(false, command.Name, "Soru kategorisi 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }

            // map command to the model
            var model = Mapper.Map<QuestionCategory>(command);

            // mark the model to insert
            questionCategoryRepository.Insert(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            // return the result
            result= new Result(true,model.Id, "Soru kategorisi başarıyla eklendi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
