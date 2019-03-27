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
    public class GetProductHandler : CommandHandler<Commands.GetProduct>
    {
        private readonly IRepository<Product> productRepository;
        public GetProductHandler(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetProduct command)
        {
            // get the model from database
            Result result;
            var model = await productRepository.GetAsync(command.Id, "Images", "Category", "Brand", "Store");

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, command.Id, "Ürün bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<ProductQuery>(model);

            // return the query result
            result = new Result(true, value, "1 adet ürün bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
