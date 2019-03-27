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
    public class GetPagesHandler : CommandHandler<Commands.GetPage>
    {
        private readonly IRepository<Page> pageRepository;
        public GetPagesHandler(IRepository<Page> pageRepository)
        {
            this.pageRepository = pageRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetPage command)
        {
            // get the model from database
            var model = pageRepository.Get(command.Id);
            Result result;
            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(true, null,  "Sayfa bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<PageQuery>(model);

            // return the query result
            result = new Result(true, value,  "1 adet sayfa bulundu.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
