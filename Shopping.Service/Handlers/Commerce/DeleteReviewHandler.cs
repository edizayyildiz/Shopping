using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteReviewHandler : CommandHandler<Commands.DeleteReview>
    {
        private readonly IRepository<Review> reviewRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteReviewHandler(IUnitOfWork unitOfWork, IRepository<Review> reviewRepository)
        {
            this.unitOfWork = unitOfWork;
            this.reviewRepository = reviewRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteReview command)
        {
            Result result;
            // get the model from database
            var model = reviewRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, command.Id, "Görüş bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // delete the model
            reviewRepository.Delete(model);
            unitOfWork.SaveChanges();


            // return the query result
            result = new Result(true, command.Id, "1 adet görüş silindi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
