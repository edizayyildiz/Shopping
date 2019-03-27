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
    public class GetAddressHandler : CommandHandler<Commands.GetAddress>
    {
        private readonly IRepository<Address> addressRepository;
        public GetAddressHandler(IRepository<Address> addressRepository)
        {
            this.addressRepository = addressRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetAddress command)
        {
            // get the model from database
            var model = addressRepository.Get(command.Id);
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
            result= new Result(true, value, "1 adet adres bulundu.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
