using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries.Commerce;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class GetAddressesHandler : CommandHandler<Commands.GetAddresses>
    {
        private readonly IRepository<Address> addressesRepository;
        public GetAddressesHandler(IRepository<Address> addressesRepository)
        {
            this.addressesRepository = addressesRepository;
        }

        public override async Task<dynamic> HandleAsync(Commands.GetAddresses command)
        {
            // define the filter
            Expression<Func<Address, bool>> where;
            where = w => w.CreatedBy == "emir";

            // get the model from database; Get tek kayıt GetAll tümünü GetMany çok kayıt döndürür
            var model = addressesRepository.GetMany(where, o => o.CreatedAt, true, "City", "Country", "District");
            Result result;

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(true, null, "Adres bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<AddressQuery>(model);

            // return the query result
            result = new Result(true, value, $"{model.Count()} adet adres bulundu.", false, model.Count());
            return await Task.FromResult(result);
        }
    }
}
