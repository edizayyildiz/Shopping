using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditAddressHandler : CommandHandler<Commands.EditAddress>
    {
        private readonly IRepository<Address> addressRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditAddressHandler(IUnitOfWork unitOfWork, IRepository<Address> addressRepository)
        {
            this.unitOfWork = unitOfWork;
            this.addressRepository = addressRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditAddress command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                result = new Result(false, command.Id, "Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.FirstName))
            {
                result = new Result(false, command.FirstName, "Adı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.FirstName.Length > 200)
            {
                result = new Result(false, command.FirstName, "Adı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.LastName))
            {
                result = new Result(false, command.LastName, "Soyadı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.LastName.Length > 200)
            {
                result = new Result(false, command.LastName, "Soyadı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (!string.IsNullOrEmpty(command.MiddleName) && command.MiddleName.Length > 200)
            {
                result = new Result(false, command.MiddleName, "Orta Adı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (!string.IsNullOrEmpty(command.Email) && command.Email.Length > 50)
            {
                result = new Result(false, command.Email, "Email 50 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (!string.IsNullOrEmpty(command.Company) && command.Company.Length > 200)
            {
                result = new Result(false, command.Company, "Firma Adı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (!string.IsNullOrEmpty(command.IdentityNumber) && command.IdentityNumber.Length > 100)
            {
                result = new Result(false, command.Company, "Kimlik No 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }


            // map command to the model
            var model = Mapper.Map<Address>(command);

            // mark the model to update
            addressRepository.Update(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            result = new Result(true, model.Id, "Adres başarıyla güncellendi.", true, 1);
            // return the result
            return await Task.FromResult(result);
        }
    }
}
