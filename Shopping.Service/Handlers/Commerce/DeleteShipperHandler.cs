using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteShipperHandler : CommandHandler<Commands.DeleteShipper>
    {
        private readonly IRepository<Shipper> shipperRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteShipperHandler(IUnitOfWork unitOfWork, IRepository<Shipper> shipperRepository)
        {
            this.unitOfWork = unitOfWork;
            this.shipperRepository = shipperRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteShipper command)
        {
            Result result;
            // get the model from database
            var model =await shipperRepository.GetAsync(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result= new Result( true, null, "Kargo firması bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // delete the model
            shipperRepository.Delete(model);
           await unitOfWork.SaveChangesAsync();


            // return the query result
            result=new Result( true, command.Id, "1 adet kargo firması silindi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
