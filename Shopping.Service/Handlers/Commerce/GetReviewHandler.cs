using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class GetReviewHandler : CommandHandler<Commands.GetReview>
    {
        private readonly IRepository<Review> reviewRepository;
        public GetReviewHandler(IRepository<Review> reviewRepository)
        {
            this.reviewRepository = reviewRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetReview command)
        {
            Result result;
            // get the model from database
            var model = reviewRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, command.Id, "Görüş bulunamadı.", false, null);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<ReviewQuery>(model);

            // return the query result
            result = new Result(true, command.Id, "1 adet görüş bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
