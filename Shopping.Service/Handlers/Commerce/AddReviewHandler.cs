using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class AddReviewHandler : CommandHandler<Commands.AddReview>
    {
        private readonly IRepository<Review> reviewRepository;
        private readonly IUnitOfWork unitOfWork;
        public AddReviewHandler(IUnitOfWork unitOfWork, IRepository<Review> reviewRepository)
        {
            this.unitOfWork = unitOfWork;
            this.reviewRepository = reviewRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddReview command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                
                result = new Result(false, command.Name, " Ad gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Name.Length > 200)
            {
                result = new Result(false, command.Name.Length, " en fazla 200 gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Email))
            {
                result = new Result(false, command.Email, " en fazla 200 gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Email.Length > 200)
            {
                result = new Result(false, command.Email.Length, " en fazla 200 gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.ProductId))
            {
                result = new Result(false, command.ProductId, " en fazla 200 gereklidir.", true, null);
                return await Task.FromResult(result);
            }


            // map command to the model
            var model = Mapper.Map<Review>(command);

            // mark the model to insert
            reviewRepository.Insert(model);

            // save changes to database
            unitOfWork.SaveChanges();

            // return the result
            return new Result(true, model.Id, "Görüş başarıyla eklendi.", false, 1);
        }
    }
}
