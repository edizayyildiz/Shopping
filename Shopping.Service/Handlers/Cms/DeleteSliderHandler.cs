using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteSliderHandler : CommandHandler<Commands.DeleteSlider>
    {
        private readonly IRepository<Slider> sliderRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteSliderHandler(IUnitOfWork unitOfWork, IRepository<Slider> sliderRepository)
        {
            this.unitOfWork = unitOfWork;
            this.sliderRepository = sliderRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteSlider command)
        {
            // get the model from database
            var model = sliderRepository.Get(command.Id);
            Result result;
            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(true, command.Id, "Kaydırıcı bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // delete the model
             sliderRepository.Delete(model);
           await unitOfWork.SaveChangesAsync();


            // return the query result
            result = new Result(true, command.Id, "1 adet kaydırıcı silindi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
