using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteDistrictHandler : CommandHandler<Commands.DeleteDistrict>
    {
        private readonly IRepository<District> districtRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteDistrictHandler(IUnitOfWork unitOfWork, IRepository<District> districtRepository)
        {
            this.unitOfWork = unitOfWork;
            this.districtRepository = districtRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteDistrict command)
        {
            Result result;
            // get the model from database
            var model = districtRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, command.Id, "İlçe bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // delete the model
            districtRepository.Delete(model);
            unitOfWork.SaveChanges();


            // return the query result
            result = new Result(true, command.Id, "1 adet ilçe silindi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
