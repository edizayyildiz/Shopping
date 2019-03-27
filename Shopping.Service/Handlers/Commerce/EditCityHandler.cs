using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditCityHandler : CommandHandler<Commands.EditCity>
    {
        private readonly IRepository<City> cityRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditCityHandler(IUnitOfWork unitOfWork, IRepository<City> cityRepository)
        {
            this.unitOfWork = unitOfWork;
            this.cityRepository = cityRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditCity command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                result = new Result(false, command.Id, "Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                result = new Result(false, command.Name, "Şehir Adı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Name.Length > 200)
            {
                result= new Result(false, command.Name, "Şehir Adı 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.CountryId))
            {   
                result = new Result(false, command.CountryId, "Ülke ID gereklidir", true, null);
                return await Task.FromResult(result);
            }

            // map command to the model
            var model = Mapper.Map<City>(command);

            // mark the model to update
            cityRepository.Update(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            // return the result
            result = new Result(true, model.Id, "Şehir başarıyla güncellendi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
