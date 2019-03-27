using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class EditDistrictHandler : CommandHandler<Commands.EditDistrict>
    {
        private readonly IRepository<District> districtRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditDistrictHandler(IUnitOfWork unitOfWork, IRepository<District> districtRepository)
        {
            this.unitOfWork = unitOfWork;
            this.districtRepository = districtRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditDistrict command)
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
                result = new Result(false, command.Name, "İlçe Adı gereklidir.", true, null);
                return await Task.FromResult(result);
               
            }
            if (command.Name.Length > 200)
            {
                result = new Result(false, command.Name, "İlçe Adı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.CityId))
            {
                result = new Result(false, command.CityId, "Şehir ID gereklidir.", true, null);
                return await Task.FromResult(result);
            }

            // map command to the model
            var model = Mapper.Map<District>(command);

            // mark the model to update
            districtRepository.Update(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            // return the result
            result = new Result(true, model.Id, "İlçe başarıyla güncellendi.", false, 1);
            return await Task.FromResult(result);
           
        }
    }
}
