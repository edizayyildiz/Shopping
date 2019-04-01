using AutoMapper;
using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class GetRecentlyDisplayedProductHandler : CommandHandler<Commands.GetRecentlyDisplayedProduct>
    {
        private readonly IRepository<RecentlyDisplayedProduct> repository;
        public GetRecentlyDisplayedProductHandler(IRepository<RecentlyDisplayedProduct> repository)
        {
            this.repository = repository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetRecentlyDisplayedProduct command)
        {
            // get the model from database
            Result result;
            var model = await repository.GetAsync(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, command.Id, "Ürün son görüntülenmesi bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<RecentlyDisplayedProductQuery>(model);

            // return the query result
            result = new Result(true, value, "1 adet ürünün son görüntülenmesi bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
