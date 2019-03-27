using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class GetDistrictHandler : CommandHandler<Commands.GetDistrict>
    {
        private readonly IRepository<District> districtRepository;
        public GetDistrictHandler(IRepository<District> districtRepository)
        {
            this.districtRepository = districtRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetDistrict command)
        {
            Result result;
            // get the model from database
            var model = districtRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                result = new Result(true, command.Id, "İlçe bulunamadı.", true, 0);
                // return the not found result
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<DistrictQuery>(model);

            // return the query result
            result = new Result(true, value, "1 adet ilçe bulundu.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
