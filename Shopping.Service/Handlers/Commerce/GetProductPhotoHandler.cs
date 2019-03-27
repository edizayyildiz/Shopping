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

    public class GetProductPhotoHandler : CommandHandler<Commands.GetProductPhoto>
    {
        private readonly IRepository<ProductPhoto> productphotoRepository;
        public GetProductPhotoHandler(IRepository<ProductPhoto> productphotoRepository)
        {
            this.productphotoRepository = productphotoRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetProductPhoto command)
        {
            Result result;
            // get the model from database
            var model = productphotoRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, command.Id, "Ürün resmi bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<ProductPhotoQuery>(model);

            // return the query result
            result = new Result(true, value, "1 adet ürün rengi bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }

}
