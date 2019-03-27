using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class DeleteCityHandler : CommandHandler<Commands.DeleteCity>
    {
        private readonly IRepository<City> cityRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteCityHandler(IUnitOfWork unitOfWork, IRepository<City> cityRepository)
        {
            this.unitOfWork = unitOfWork;
            this.cityRepository = cityRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteCity command)
        {
            Result result;
            // get the model from database
            var model = cityRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                result = new Result(true, null, "Şehir bulunamadı.", true, 0);
                return await Task.FromResult(result);
                // return the not found result

            }
            // delete the model
            cityRepository.Delete(model);
             await unitOfWork.SaveChangesAsync();


            // return the query result
            result = new Result(true, command.Id, "1 adet şehir silindi.", false, 1);
            return await Task.FromResult(result);
            //return new Result(command.Id, true, "1 adet şehir silindi.", false, 1);
        }
    }
}
