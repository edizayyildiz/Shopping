using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Commerce
{
    public class EditReviewHandler : CommandHandler<Commands.EditReview>
    {
        private readonly IRepository<Review> reviewRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditReviewHandler(IUnitOfWork unitOfWork, IRepository<Review> reviewRepository)
        {
            this.unitOfWork = unitOfWork;
            this.reviewRepository = reviewRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditReview command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                result = new Result(false, command.Id, "Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                result = new Result(false, command.Name, "Ad gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Name.Length > 200)
            {
                result = new Result(false, command.Name, "Ad 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Email))
            {
                result = new Result(false, command.Email, "Email gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Email.Length > 200)
            {
                result = new Result(false, command.Email, "Email 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.ProductId))
            {
                result = new Result(false, command.ProductId, "Ürün Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            // map command to the model
            var model = Mapper.Map<Review>(command);

            // mark the model to update
            reviewRepository.Update(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            result = new Result(true, model.Id, "Görüş başarıyla güncellendi.", true, 1);
            // return the result
            return await Task.FromResult(result);
        }
    }
}
