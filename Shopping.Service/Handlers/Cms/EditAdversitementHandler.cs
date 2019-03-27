using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditAdvertisementHandler : CommandHandler<Commands.EditAdvertisement>
    {
        private readonly IRepository<Advertisement> advertisementRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditAdvertisementHandler(IUnitOfWork unitOfWork, IRepository<Advertisement> advertisementRepository)
        {
            this.unitOfWork = unitOfWork;
            this.advertisementRepository = advertisementRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditAdvertisement command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                result= new Result(false,command.Id, "Id gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Title))
            {
                result= new Result(false,command.Title, "Reklam Başlığı gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Title.Length > 200)
            {
                result= new Result(false,command.Title, "Reklam Başlığı 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Location))
            {
                result= new Result(false,command.Location, "Konum gereklidir.", true,null);
                return await Task.FromResult(result);
            }
            if (command.Location.Length > 200)
            {
                result= new Result(false, command.Location, "Konum 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            // map command to the model
            var model = Mapper.Map<Advertisement>(command);

            // mark the model to update
            advertisementRepository.Update(model);

            // save changes to database
           await unitOfWork.SaveChangesAsync();

            // return the result
            result= new Result( true, model.Id, "Reklam başarıyla güncellendi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
