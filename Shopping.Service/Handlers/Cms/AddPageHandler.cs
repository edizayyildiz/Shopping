using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class AddPageHandler : CommandHandler<Commands.AddPage>
    {
        private readonly IRepository<Page> pageRepository;
        private readonly IUnitOfWork unitOfWork;
        
        public AddPageHandler(IUnitOfWork unitOfWork, IRepository<Page> pageRepository)
        {
            this.unitOfWork = unitOfWork;
            this.pageRepository = pageRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddPage command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Title))
            {
                result=  new Result(false,command.Title, "Başlık gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Title.Length > 200)
            {
                result =  new Result(false, command.Title, "Başlık 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Slug))
            {
                result = new Result(false, command.Slug, "Bağlantı gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Slug.Length > 200)
            {
                result =  new Result(false, command.Slug, "Bağlantı 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Photo))
            {
                result = new Result(false, command.Photo, "Resim gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Photo.Length > 200)
            {
                result = new Result(false, command.Photo, "Resim 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.MetaTitle))
            {
                result = new Result(false, command.MetaTitle, "Meta Başlığı gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.MetaTitle.Length > 200)
            {
                result = new Result(false, command.MetaTitle, "Meta Başlığı 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }


            // map command to the model
            var model = Mapper.Map<Page>(command);

            // mark the model to insert
            pageRepository.Insert(model);

            // save changes to database
            unitOfWork.SaveChanges();

            // return the result
            result =  new Result(true, model.Id, "Sayfa başarıyla eklendi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
