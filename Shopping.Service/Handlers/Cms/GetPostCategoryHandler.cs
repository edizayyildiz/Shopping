using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Cms
{
    public class GetPostCategoryHandler : CommandHandler<Commands.GetPostCategory>
    {
        private readonly IRepository<PostCategory> postcategoryRepository;
        public GetPostCategoryHandler(IRepository<PostCategory> postcategoryRepository)
        {
            this.postcategoryRepository = postcategoryRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetPostCategory command)
        {
            Result result;
            // get the model from database
            var model = postcategoryRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                result = new Result(true, command.Id, "Yazı kategorisi bulunamadı.", true, 0);
                // return the not found result
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<PostCategoryQuery>(model);

            result = new Result(true, value, "1 adet yazı kategorisi bulundu.", false, 1);
            // return the query result
            return await Task.FromResult(result);
        }
    }
}
