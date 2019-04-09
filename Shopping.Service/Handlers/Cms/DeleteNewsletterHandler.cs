using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class DeleteNewsletterHandler : CommandHandler<Commands.DeleteNewsletter>
    {
        private readonly IRepository<Newsletter> newsletterRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteNewsletterHandler(IUnitOfWork unitOfWork, IRepository<Newsletter> newsletterRepository)
        {
            this.unitOfWork = unitOfWork;
            this.newsletterRepository = newsletterRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteNewsletter command)
        {
            Result result;
            // get the model from database
            var model = await newsletterRepository.GetAsync(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(true, model.Id, "Abone bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // delete the model
            newsletterRepository.Delete(model);
            await unitOfWork.SaveChangesAsync();


            // return the query result
            result = new Result(true, command.Id, "1 adet abone silindi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}