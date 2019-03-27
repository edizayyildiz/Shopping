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
    public class GetCityHandler : CommandHandler<Commands.GetCity>
    {
        private readonly IRepository<City> cityRepository;
        public GetCityHandler(IRepository<City> cityRepository)
        {
            this.cityRepository = cityRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetCity command)
        {
            Result result;
            // get the model from database
            var model =  await cityRepository.GetAsync(command.Id);

            // if nothing found
            if (model == null)
            {
                result = new Result(false, command.Id, "Şehir bulunamadı.", true, null);
                return await Task.FromResult(result);
                // return the not found result
               
            }
            // map the model to query
            var value = Mapper.Map<CityQuery>(model);

            // return the query result
            result = new Result(true, value, "1 adet şehir bulundu.", true, 1);
            return await Task.FromResult(result);
            //return new Result(value, true, "1 adet şehir bulundu.", false, 1);
        }
    }
}
