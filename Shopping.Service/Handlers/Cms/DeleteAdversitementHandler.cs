using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Cms
{
    public class DeleteAdvertisementHandler : CommandHandler<Commands.DeleteAdvertisement>
    {
        private readonly IRepository<Advertisement> advertisementRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteAdvertisementHandler(IUnitOfWork unitOfWork, IRepository<Advertisement> advertisementRepository)
        {
            this.unitOfWork = unitOfWork;
            this.advertisementRepository = advertisementRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteAdvertisement command)
        {
            Result result;
            // get the model from database
            var model = await advertisementRepository.GetAsync(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result= new Result( true,model.Id, "Reklam bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // delete the model
            advertisementRepository.Delete(model);
           await unitOfWork.SaveChangesAsync();


            // return the query result
            result= new Result( true, command.Id, "1 adet reklam silindi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
