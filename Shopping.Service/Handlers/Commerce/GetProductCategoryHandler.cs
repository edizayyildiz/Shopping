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
    public class GetProductCategoryHandler : CommandHandler<Commands.GetProductCategory>
    {
        Result result;
        private readonly IRepository<ProductCategory> productcategoryRepository;
        public GetProductCategoryHandler(IRepository<ProductCategory> productcategoryRepository)
        {
            this.productcategoryRepository = productcategoryRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetProductCategory command)
        {
            // get the model from database
            var model = productcategoryRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(true, command.Id, "Ürün kategorisi bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<ProductCategoryQuery>(model);

            // return the query result
            result = new Result(true, model.Id, "1 adet ürün kategorisi bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
