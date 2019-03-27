using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteSlideHandler : CommandHandler<Commands.DeleteSlide>
    {
        private readonly IRepository<Slide> slideRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteSlideHandler(IUnitOfWork unitOfWork, IRepository<Slide> slideRepository)
        {
            this.unitOfWork = unitOfWork;
            this.slideRepository = slideRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteSlide command)
        {
            // get the model from database
            var model = slideRepository.Get(command.Id);
            Result result;
            // if nothing found
            if (model == null)
            { 
                // return the not found result
                result = new Result(false, command.Id, "Slayt bulunamadı.", true, null);
                return await Task.FromResult(result);         
            }
            // delete the model
            slideRepository.Delete(model);
           await unitOfWork.SaveChangesAsync();


            // return the query result
            result = new Result(true, command.Id, "1 adet slayt silindi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
