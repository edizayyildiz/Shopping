using AutoMapper;
using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditFeedbackHandler:CommandHandler<Commands.EditFeedback>
    {
        private readonly IRepository<Feedback> feedbackRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditFeedbackHandler(IUnitOfWork unitOfWork, IRepository<Feedback> feedbackRepository)
        {
            this.unitOfWork = unitOfWork;
            this.feedbackRepository = feedbackRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditFeedback command)
        {
            Result result;
            // validate the command
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
                result = new Result(false, command.Email, "E-mail gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Email.Length > 200)
            {
                result = new Result(false, command.Email, "E-mail 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Subject))
            {
                result = new Result(false, command.Subject, "Konu gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Subject.Length > 200)
            {
                result = new Result(false, command.Subject, "Konu 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Subject))
            {
                result = new Result(false, command.Message, "Mesaj alanı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Message.Length > 200)
            {
                result = new Result(false, command.Message, "Mesaj 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            // map command to the model
            var model = Mapper.Map<Feedback>(command);

            // mark the model to update
            feedbackRepository.Update(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            // return the result
            result = new Result(true, model.Id, "Geri bildirim başarıyla güncellendi.", false, 1);
            return await Task.FromResult(result);
        }

    }
}
