using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteCountryHandler : CommandHandler<Commands.DeleteCountry>
    {
        private readonly IRepository<Country> countryRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteCountryHandler(IUnitOfWork unitOfWork, IRepository<Country> countryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.countryRepository = countryRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteCountry command)
        {
            Result result;
            // get the model from database
            var model = countryRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, command.Id, "Ülke bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // delete the model
            countryRepository.Delete(model);
            unitOfWork.SaveChanges();


            // return the query result
            result = new Result(true, command.Id,  "1 adet ülke silindi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
