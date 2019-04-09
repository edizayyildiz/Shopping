using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteFeedbackHandler:CommandHandler<Commands.DeleteFeedback>
    {
        private readonly IRepository<Feedback> feedbackRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteFeedbackHandler(IUnitOfWork unitOfWork, IRepository<Feedback> feedbackRepository)
        {
            this.unitOfWork = unitOfWork;
            this.feedbackRepository = feedbackRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteFeedback command)
        {
            Result result;
            // get the model from database
            var model = await feedbackRepository.GetAsync(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(true, model.Id, "Geri bildirim bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // delete the model
            feedbackRepository.Delete(model);
            await unitOfWork.SaveChangesAsync();


            // return the query result
            result = new Result(true, command.Id, "1 adet geri bildirim silindi.", false, 1);
            return await Task.FromResult(result);
        }

    }
}
