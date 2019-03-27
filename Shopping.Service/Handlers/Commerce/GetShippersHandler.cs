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
    public class GetShippersHandler : CommandHandler<Commands.GetShipper>
    {
        private readonly IRepository<Shipper> shipperRepository;
        public GetShippersHandler(IRepository<Shipper> shipperRepository)
        {
            this.shipperRepository = shipperRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetShipper command)
        {
            // get the model from database
            var model = shipperRepository.Get(command.Id);
            Result result;
            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(true, null, "Kargo Firması bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<ShipperQuery>(model);

            // return the query result
            result = new Result(true, value, "1 adet kargo firması bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
