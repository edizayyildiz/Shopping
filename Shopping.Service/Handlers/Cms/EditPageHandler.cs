using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditPageHandler : CommandHandler<Commands.EditPage>
    {
        private readonly IRepository<Page> pageRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditPageHandler(IUnitOfWork unitOfWork, IRepository<Page> pageRepository)
        {
            this.unitOfWork = unitOfWork;
            this.pageRepository = pageRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditPage command)
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
            if (string.IsNullOrWhiteSpace(command.Photo))
            {
                result = new Result(false, command.Photo, "Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Photo.Length > 200)
            {
                result = new Result(false, command.Photo, "Id gereklidir.", true, null);
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
            var model = Mapper.Map<Page>(command);

            // mark the model to update
            pageRepository.Update(model);

            await unitOfWork.SaveChangesAsync();

            // return the result
            result =  new Result(true, model.Id, "Sayfa başarıyla güncellendi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
