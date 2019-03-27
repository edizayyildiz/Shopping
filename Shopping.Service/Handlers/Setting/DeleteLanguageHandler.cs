using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Setting
{
    public class DeleteLanguageHandler : CommandHandler<Commands.DeleteLanguage>
    {
        private readonly IRepository<Language> languageRepository;
        private readonly IUnitOfWork unitOfWork;
        public DeleteLanguageHandler(IUnitOfWork unitOfWork, IRepository<Language> languageRepository)
        {
            this.unitOfWork = unitOfWork;
            this.languageRepository = languageRepository;

        }
        public override async Task<dynamic> HandleAsync(Commands.DeleteLanguage command)
        {
            Result result;
            // get the model from database
            var model = await languageRepository.GetAsync(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result= new Result( true,model.Id, "Dil bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // delete the model
            languageRepository.Delete(model);
           await unitOfWork.SaveChangesAsync();


            // return the query result
            result= new Result( true, command.Id, "1 adet dil silindi.", false, 1);

            return await Task.FromResult(result);
        }
    }
}
