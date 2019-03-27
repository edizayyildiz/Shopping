using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteStoreHandler : CommandHandler<Commands.DeleteStore>
    {
        private readonly IRepository<Model.Entities.Store> storeRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteStoreHandler(IUnitOfWork unitOfWork, IRepository<Model.Entities.Store> storeRepository)
        {
            this.unitOfWork = unitOfWork;
            this.storeRepository = storeRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteStore command)
        {
            // get the model from database
            var model = storeRepository.Get(command.Id);
            Result result;
            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false,command.Id, "Mağaza bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // delete the model
            storeRepository.Delete(model);
            await unitOfWork.SaveChangesAsync();


            // return the query result
            result = new Result(true,command.Id, "1 adet mağaza silindi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
