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
    public class GetPostPostCategoryHandler : CommandHandler<Commands.GetPostPostCategory>
    {
        private readonly IRepository<PostPostCategory> postpostcategoryRepository;
        public GetPostPostCategoryHandler(IRepository<PostPostCategory> postpostcategoryRepository)
        {
            this.postpostcategoryRepository = postpostcategoryRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetPostPostCategory command)
        {
            Result result;
            // get the model from database
            var model = postpostcategoryRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                result = new Result(true, command.Id, "Yazı ile yazı kategorisi arasındaki ilişki bulunamadı.", true, 0);
                // return the not found result
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<PostPostCategoryQuery>(model);

            // return the query result
            result = new Result(true, value, "1 adet yazı ile yazı kategorisi arasındaki ilişki bulundu.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
