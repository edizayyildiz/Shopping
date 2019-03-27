using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class AddSlideHandler : CommandHandler<Commands.AddSlide>
    {
        private readonly IRepository<Slide> slideRepository;
        private readonly IUnitOfWork unitOfWork;
        public AddSlideHandler(IUnitOfWork unitOfWork, IRepository<Slide> slideRepository)
        {
            this.unitOfWork = unitOfWork;
            this.slideRepository = slideRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddSlide command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                result = new Result(false, command.Name, "Slayt Adı gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Name.Length > 200)
            {
                result= new Result(false, command.Name, "Slayt Adı 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Title))
            {
                result= new Result(false, command.Title, "Slayt Başlığı gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Title.Length > 200)
            {
                result= new Result(false, command.Title, "Slayt Başlığı 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Text))
            {
                result= new Result(false, command.Text, "Metin gereklidir.", true,null);
            }
            if (command.Text.Length > 200)
            {
                result= new Result(false, command.Text, "Metin 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Url))
            {
                result= new Result(false, command.Url, "Url gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Url.Length > 200)
            {
                result= new Result(false, command.Url, "Url 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Photo))
            {
                result= new Result(false, command.Photo, "Resim gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Photo.Length > 200)
            {
                result= new Result(false, command.Photo, "Resim 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }




            // map command to the model
            var model = Mapper.Map<Slide>(command);

            // mark the model to insert
            slideRepository.Insert(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            // return the result
            result = new Result(true , model.Id, "Slayt başarıyla eklendi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
