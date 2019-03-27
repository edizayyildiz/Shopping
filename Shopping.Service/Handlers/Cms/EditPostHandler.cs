using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditPostHandler : CommandHandler<Commands.EditPost>
    {
        private readonly IRepository<Post> postRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditPostHandler(IUnitOfWork unitOfWork, IRepository<Post> postRepository)
        {
            this.unitOfWork = unitOfWork;
            this.postRepository = postRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditPost command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                result = new Result(false, command.Id, "Id gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Title))
            {
                result = new Result(false, command.Title, "Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Title.Length > 200)
            {
                result = new Result(false, command.Title, "Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Slug))
            {
                result = new Result(false, command.Slug, "Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Slug.Length > 200)
            {
                result = new Result(false, command.Slug, "Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.MetaTitle))
            {
                result = new Result(false, command.MetaTitle, "Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.MetaTitle.Length > 200)
            {
                result = new Result(false, command.MetaTitle, "Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }

            // map command to the model
            var model = Mapper.Map<Post>(command);

            // mark the model to update
            postRepository.Update(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            // return the result
            result = new Result(true, model.Id,  "Yazı başarıyla güncellendi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
