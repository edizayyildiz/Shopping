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
    public class GetProductQuestionHandler : CommandHandler<Commands.GetProductQuestion>
    {
        private readonly IRepository<ProductQuestion> productQuestionRepository;
        public GetProductQuestionHandler(IRepository<ProductQuestion> productQuestionRepository)
        {
            this.productQuestionRepository = productQuestionRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetProductQuestion command)
        {
            Result result;
            // get the model from database
            var model = productQuestionRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, command.Id, "Ürün sorusu bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<ProductQuestionQuery>(model);

            // return the query result
            result = new Result(true, value, "1 adet ürün sorusu bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
