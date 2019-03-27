using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Cms
{
    public class AddPostCategoryHandler : CommandHandler<Commands.AddPostCategory>
    {
        private readonly IRepository<PostCategory> postcategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public AddPostCategoryHandler(IUnitOfWork unitOfWork, IRepository<PostCategory> postcategoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.postcategoryRepository = postcategoryRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddPostCategory command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                result = new Result(false, command.Name, "Yazı kategorisi adı gereklidir.", true, null);
                return await Task.FromResult(result);              
            }
            if (command.Name.Length > 200)
            {
                result = new Result(false, command.Name, "Yazı kategorisi adı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Slug))
            {
                result = new Result(false, command.Slug, "Bağlantı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Slug.Length > 200)
            {
                result = new Result(false, command.Slug, "Bağlantı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Photo))
            {
                result = new Result(false, command.Photo, "Resim gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Photo.Length > 200)
            {
                result = new Result(false, command.Photo, "Resim 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }


            // map command to the model
            var model = Mapper.Map<PostCategory>(command);

            // mark the model to insert
            postcategoryRepository.Insert(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            result = new Result(true, model.Id, " Yazı kategorisi başarıyla eklendi.", true, 1);
            // return the result
            return await Task.FromResult(result);
        }
    }
}
