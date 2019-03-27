using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class AddPostHandler : CommandHandler<Commands.AddPost>
    {
        private readonly IRepository<Post> postRepository;
        private readonly IUnitOfWork unitOfWork;
        public AddPostHandler(IUnitOfWork unitOfWork, IRepository<Post> postRepository)
        {
            this.unitOfWork = unitOfWork;
            this.postRepository = postRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddPost command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Title))
            {
                result = new Result(false, command.Title, "Yazı Başlığı gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Title.Length > 200)
            {
                result = new Result(false, command.Title, "Yazı Başlığı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Slug))
            {
                result = new Result(false, command.Slug, "Yazı Başlığı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Slug.Length > 200)
            {
                result = new Result(false, command.Slug, "Yazı Başlığı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.MetaTitle))
            {
                result = new Result(false, command.MetaTitle, "Yazı Başlığı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.MetaTitle.Length > 200)
            {
                result = new Result(false, command.MetaTitle, "Yazı Başlığı gereklidir.", true, null);
                return await Task.FromResult(result);
            }


            // map command to the model
            var model = Mapper.Map<Post>(command);

            // mark the model to insert
            postRepository.Insert(model);

            // save changes to database
            unitOfWork.SaveChanges();

            // return the result
            result =  new Result(true, model.Id, "Yazı başarıyla eklendi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
