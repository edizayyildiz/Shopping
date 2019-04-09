using AutoMapper;
using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class GetNewsletterHandler : CommandHandler<Commands.GetNewsletter>
    {
        private readonly IRepository<Newsletter> newsletterRepository;
        public GetNewsletterHandler(IRepository<Newsletter> newsletterRepository)
        {
            this.newsletterRepository = newsletterRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetNewsletter command)
        {
            // get the model from database
            var model = newsletterRepository.Get(command.Id);
            Result result;
            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(true, null, "Abone bulunamadı.", true, 0);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<PageQuery>(model);

            // return the query result
            result = new Result(true, value, "1 adet abone bulundu.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
