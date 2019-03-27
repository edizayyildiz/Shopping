using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Cms
{
    public class AddPostPostCategoryHandler : CommandHandler<Commands.AddPostPostCategory>
    {
        private readonly IRepository<PostPostCategory> postpostcategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public AddPostPostCategoryHandler(IUnitOfWork unitOfWork, IRepository<PostPostCategory> postpostcategoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.postpostcategoryRepository = postpostcategoryRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddPostPostCategory command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.PostId))
            {
                result = new Result(false, command.PostId, "Yazı Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.PostCategoryId))
            {
                result = new Result(false, command.PostCategoryId, "Yazı Kategorisi Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }



            // map command to the model
            var model = Mapper.Map<PostPostCategory>(command);

            // mark the model to insert
            postpostcategoryRepository.Insert(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            result = new Result(true, model.Id, " Yazı ile yazı kategorisi arasındaki ilişki başarıyla eklendi.", true, 1);
            // return the result
            return await Task.FromResult(result);
        }
    }
}
