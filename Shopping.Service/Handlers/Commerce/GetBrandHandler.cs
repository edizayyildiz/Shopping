using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{

    public class GetBrandHandler : CommandHandler<Commands.GetBrand>
    {
        private readonly IRepository<Brand> brandRepository;
        public GetBrandHandler(IRepository<Brand> brandRepository)
        {
            this.brandRepository = brandRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetBrand command)
        {
            Result result;
            // get the model from database
            var model = brandRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, command.Id, "Marka bulunamadı.", false, null);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<BrandQuery>(model);

            // return the query result
            result = new Result(true, command.Id, "1 adet marka bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
