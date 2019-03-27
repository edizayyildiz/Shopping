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

    public class GetProductColorHandler : CommandHandler<Commands.GetProductColor>
    {
        private readonly IRepository<ProductColor> productcolorRepository;
        public GetProductColorHandler(IRepository<ProductColor> productcolorRepository)
        {
            this.productcolorRepository = productcolorRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetProductColor command)
        {
            // get the model from database
            Result result;
            var model = await productcolorRepository.GetAsync(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result               
                result = new Result(false, command.Id, "Ürün rengi bulunamadı.", true, null);
                return await Task.FromResult(result);
                               
            }
            // map the model to query
            var value = Mapper.Map<ProductColorQuery>(model);

            // return the query result           
            result = new Result(true, value, "1 adet ürün rengi bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }

}
