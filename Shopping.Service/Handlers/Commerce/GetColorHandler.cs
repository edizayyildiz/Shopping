using Shopping.Data;
using Shopping.Model.Entities;
using Shopping.Service.Queries.Commerce;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class GetColorHandler : CommandHandler<Commands.GetColor>
    {
        private readonly IRepository<Color> colorRepository;
        public GetColorHandler(IRepository<Color> colorRepository)
        {
            this.colorRepository = colorRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetColor command)
        {
            Result result;
            // get the model from database
            var model = colorRepository.Get(command.Id);

            // if nothing found
            if (model == null)
            {
                // return the not found result
                result = new Result(false, command.Id, "Renk bulunamadı.", true, null);
                return await Task.FromResult(result);
            }
            // map the model to query
            var value = Mapper.Map<ColorQuery>(model);

            // return the query result           

            result = new Result(true, value, "1 adet renk bulundu.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
