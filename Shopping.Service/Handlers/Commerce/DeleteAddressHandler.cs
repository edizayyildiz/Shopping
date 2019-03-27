using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteAddressHandler : CommandHandler<Commands.DeleteAddress>
    {
        private readonly IRepository<Address> addressRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteAddressHandler(IUnitOfWork unitOfWork, IRepository<Address> addressRepository)
        {
            this.unitOfWork = unitOfWork;
            this.addressRepository = addressRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteAddress command)
        {
            Result result;
            // get the model from database
            var model = addressRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                result = new Result(false, command.Id, "Adres bulunamadı.", true, 0);
                // return the not found result
                return await Task.FromResult(result);
            }
            // delete the model
            addressRepository.Delete(model);
            unitOfWork.SaveChanges();

            result = new Result(true, command.Id, "1 adet adres silindi.", false, 1);
            // return the query result
            return await Task.FromResult(result);
        }
    }
}
