using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditCountryHandler : CommandHandler<Commands.EditCountry>
    {
        private readonly IRepository<Country> countryRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditCountryHandler(IUnitOfWork unitOfWork, IRepository<Country> countryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.countryRepository = countryRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditCountry command)
        {

            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                result = new Result(false, command.Id, " id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                result = new Result(false, command.Name, "Bağlantı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Name.Length > 200)
            {
                result = new Result(false, command.Name, "Ad gereklidir.", true, null);
                return await Task.FromResult(result);
            }


            // map command to the model
            var model = Mapper.Map<Country>(command);

            // mark the model to update
            countryRepository.Update(model);

            // save changes to database
         unitOfWork.SaveChanges();

            // return the result
            return new Result(true, model.Id, "Ülke başarıyla güncellendi.", false, 1);
        }
    }
}
