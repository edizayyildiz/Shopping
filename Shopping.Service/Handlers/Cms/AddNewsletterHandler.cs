using AutoMapper;
using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class AddNewsletterHandler : CommandHandler<Commands.AddNewsletter>
    {
        private readonly IRepository<Newsletter> newsletterRepository;
        private readonly IUnitOfWork unitOfWork;


        public AddNewsletterHandler(IUnitOfWork unitOfWork, IRepository<Newsletter> newsletterRepository)
        {
            this.newsletterRepository = newsletterRepository;
            this.unitOfWork = unitOfWork;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddNewsletter command)
        {
            Result result;

            if (string.IsNullOrWhiteSpace(command.Fullname))
            {
                result = new Result(false, command.Fullname, "Abone adı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Fullname.Length > 200)
            {
                result = new Result(false, command.Fullname, "Abone adı 200 karakterden uzun olamaz.", true, null);
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
            // map command to the model
            var model = Mapper.Map<Newsletter>(command);

            // mark the model to insert
            newsletterRepository.Insert(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            result = new Result(true, model.Id, " Abone başarıyla eklendi.", true, 1);
            // return the result
            return await Task.FromResult(result);
        }
    }
}
