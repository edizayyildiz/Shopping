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
    public class GetSlideHandler : CommandHandler<Commands.GetSlide>
    {
        private readonly IRepository<Slide> slideRepository;
        public GetSlideHandler(IRepository<Slide> slideRepository)
        {
            this.slideRepository = slideRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetSlide command)
        {
            Result result;
            // get the model from database
            var model = slideRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                result = new Result(false, command.Id, "Slayt bulunamadı.", true, 0);
                // return the not found result
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<SlideQuery>(model);
            result = new Result(true, command.Id, "1 adet slayt bulundu.", false, 1);
            // return the query result
            return await Task.FromResult(result);
        }
    }
}
