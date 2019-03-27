using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class AddCountryHandler : CommandHandler<Commands.AddCountry>
    {
        private readonly IRepository<Country> countryRepository;
        private readonly IUnitOfWork unitOfWork;
        public AddCountryHandler(IUnitOfWork unitOfWork, IRepository<Country> countryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.countryRepository = countryRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddCountry command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                result = new Result(false, command.Name, "Ad gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Name.Length > 200)
            {
                result = new Result(false, command.Name, "Ad gereklidir.", true, null);
                return await Task.FromResult(result);
            }

            // map command to the model
            var model = Mapper.Map<Country>(command);

            // mark the model to insert
            countryRepository.Insert(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            // return the result
            result = new Result(true, model.Id, "Ürün başarıyla eklendi.", true, 1);
            return Task.FromResult(result);
        }
    }
}
