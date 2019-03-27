using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers.Setting
{
    public class GetLanguageHandler : CommandHandler<Commands.GetLanguage>
    {
        private readonly IRepository<Language> languageRepository;
        public GetLanguageHandler(IRepository<Language> languageRepository)
        {
            this.languageRepository = languageRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetLanguage command)
        {
            Result result;
            // get the model from database
            var model = await languageRepository.GetAsync(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result= new Result( true,command.Id, "Dil bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<LanguageQuery>(model);

            // return the query result
            result= new Result( true, value, "1 adet dil bulundu.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
