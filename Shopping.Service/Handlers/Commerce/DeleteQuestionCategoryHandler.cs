using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteQuestionCategoryHandler : CommandHandler<Commands.DeleteQuestionCategory>
    {
        private readonly IRepository<QuestionCategory> questionCategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteQuestionCategoryHandler(IUnitOfWork unitOfWork, IRepository<QuestionCategory> questionCategoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.questionCategoryRepository = questionCategoryRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteQuestionCategory command)
        {
            Result result;
            // get the model from database
            var model = questionCategoryRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, command.Id, "Soru kategorisi bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // delete the model
            questionCategoryRepository.Delete(model);
            unitOfWork.SaveChanges();


            // return the query result
            result = new Result(true, command.Id,  "1 adet soru kategorisi silindi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
