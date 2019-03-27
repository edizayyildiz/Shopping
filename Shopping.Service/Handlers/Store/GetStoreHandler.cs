using Shopping.Data;
using Shopping.Model;
using Shopping.Service.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Store
{
    public class GetStoreHandler : CommandHandler<Commands.GetStore>
    {
        private readonly IRepository<Model.Entities.Store> storeRepository;
        public GetStoreHandler(IRepository<Model.Entities.Store> storeRepository)
        {
            this.storeRepository = storeRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetStore command)
        {
            // get the model from database
            var model = storeRepository.Get(command.Id);
            Result result;
            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(true, null, "Kaydırıcı bulunamadı.", true, 0);               
               
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<StoreQuery>(model);

            // return the query result
            result = new Result(true, value, "1 adet mağaza bulundu.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
