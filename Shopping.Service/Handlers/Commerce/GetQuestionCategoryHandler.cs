using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class GetQuestionCategoryHandler : CommandHandler<Commands.GetQuestionCategory>
    {
        private readonly IRepository<QuestionCategory> questionCategoryRepository;
        public GetQuestionCategoryHandler(IRepository<QuestionCategory> questionCategoryRepository)
        {
            this.questionCategoryRepository = questionCategoryRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetQuestionCategory command)
        {
            Result result;
            // get the model from database
            var model = questionCategoryRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(true, command.Id, "Soru kategorisi bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<QuestionCategoryQuery>(model);

            // return the query result
            result = new Result(true, value, "1 adet soru kategorisi bulundu.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
