using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries.Commerce;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class GetCountryHandler : CommandHandler<Commands.GetCountry>
    {
        private readonly IRepository<Country> countryRepository;
        public GetCountryHandler(IRepository<Country> countryRepository)
        {
            this.countryRepository = countryRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetCountry command)
        {
            Result result;
            // get the model from database
            var model = await countryRepository.GetAsync(command.Id);

            // if nothing found
            if (model == null)
            {

                // return the not found result
                result = new Result(false, command.Id, "Ürün bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<CountryQuery>(model);

            // return the query result
            result = new Result(true, value, "1 adet ürün bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
