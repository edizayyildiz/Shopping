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
    public class GetSlidersHandler : CommandHandler<Commands.GetSlider>
    {
        private readonly IRepository<Slider> sliderRepository;
        public GetSlidersHandler(IRepository<Slider> sliderRepository)
        {
            this.sliderRepository = sliderRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.GetSlider command)
        {
            // get the model from database
            var model = sliderRepository.Get(command.Id);
            Result result;
            // if nothing found
            if (model == null)
            {
                result = new Result(true,null, "Kaydırıcı bulunamadı.", true, 0);
                // return the not found result
                return await Task.FromResult(result);
                    
            }
            // map the model to query
            var value = Mapper.Map<SliderQuery>(model);

            // return the query result
            result = new Result(true,value, "1 adet kaydırıcı bulundu.", false, 1);
            return await Task.FromResult(result);

            
        }
    }
}
