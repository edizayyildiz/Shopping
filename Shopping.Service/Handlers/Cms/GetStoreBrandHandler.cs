using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries.Cms;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Cms
{
    public class GetStoreBrandHandler : CommandHandler<Commands.GetStoreBrand>
    {
        private readonly IRepository<StoreBrand> storeBrandRepository;
        public GetStoreBrandHandler(IRepository<StoreBrand> storeBrandRepository)
        {
            this.storeBrandRepository = storeBrandRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetStoreBrand command)
        {
            Result result;
            // get the model from database
            var model = storeBrandRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(true, command.Id, "Mağaza markası bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<StoreBrandQuery>(model);

            // return the query result
            result = new Result(true, value, "1 adet mağaza markası bulundu.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
