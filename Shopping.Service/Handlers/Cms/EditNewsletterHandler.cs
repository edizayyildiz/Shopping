using AutoMapper;
using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditNewsletterHandler:CommandHandler<Commands.EditNewsletter>
    {
        private readonly IRepository<Newsletter> newsletterRepository;
        private readonly IUnitOfWork unitOfWork;


        public EditNewsletterHandler(IUnitOfWork unitOfWork, IRepository<Newsletter> newsletterRepository)
        {
            this.newsletterRepository = newsletterRepository;
            this.unitOfWork = unitOfWork;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditNewsletter command)
        {
            Result result;

            if (string.IsNullOrWhiteSpace(command.FullName))
            {
                result = new Result(false, command.FullName, "Abone adı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.FullName.Length > 200)
            {
                result = new Result(false, command.FullName, "Abone adı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Email))
            {
                result = new Result(false, command.Email, "Eposta gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Email.Length > 200)
            {
                result = new Result(false, command.Email, "Eposta 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            var model = Mapper.Map<Newsletter>(command);

            // mark the model to update
            newsletterRepository.Update(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            // return the result
            result = new Result(true, model.Id, "Abone başarıyla güncellendi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
