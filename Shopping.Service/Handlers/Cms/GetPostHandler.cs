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
    public class GetPostHandler : CommandHandler<Commands.GetPost>
    {
        private readonly IRepository<Post> postRepository;
        public GetPostHandler(IRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetPost command)
        {
            Result result;
            // get the model from database
            var model = postRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result= new Result(false, command.Id, "Yazı bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<PostQuery>(model);

            // return the query result
            result =new Result(true,value, "1 adet yazı bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
