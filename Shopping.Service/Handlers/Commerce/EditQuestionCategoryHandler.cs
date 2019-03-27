using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditQuestionCategoryHandler : CommandHandler<Commands.EditQuestionCategory>
    {
        private readonly IRepository<QuestionCategory> questionCategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditQuestionCategoryHandler(IUnitOfWork unitOfWork, IRepository<QuestionCategory> questionCategoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.questionCategoryRepository = questionCategoryRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditQuestionCategory command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                result = new Result(true, command.Id, "Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                result = new Result(true, command.Name, "Soru kategorisi gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Name.Length > 200)
            {
                result = new Result(true, command.Name, "Soru kategorisi 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }


            // map command to the model
            var model = Mapper.Map<QuestionCategory>(command);

            // mark the model to update
            questionCategoryRepository.Update(model);

            // save changes to database
            unitOfWork.SaveChanges();

            // return the result
            result = new Result(true, model.Id, "Soru kategorisi başarıyla güncellendi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
