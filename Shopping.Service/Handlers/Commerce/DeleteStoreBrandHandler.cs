using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class DeleteStoreBrandHandler : CommandHandler<Commands.DeleteStoreBrand>
    {
        private readonly IRepository<StoreBrand> storeBrandRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteStoreBrandHandler(IUnitOfWork unitOfWork, IRepository<StoreBrand> storeBrandRepository)
        {
            this.unitOfWork = unitOfWork;
            this.storeBrandRepository = storeBrandRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteStoreBrand command)
        {
            Result result;
            // get the model from database
            var model =await storeBrandRepository.GetAsync(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result= new Result( true, null, "Mağaza markası bulunamadı.", true, 0);
                return await Task.FromResult(result);

            }
            // delete the model
            storeBrandRepository.Delete(model);
            unitOfWork.SaveChanges();


            // return the query result
            result= new Result( true, command.Id, "1 adet mağaza markası silindi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
