using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditSliderHandler : CommandHandler<Commands.EditSlider>
    {
        private readonly IRepository<Slider> sliderRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditSliderHandler(IUnitOfWork unitOfWork, IRepository<Slider> sliderRepository)
        {
            this.unitOfWork = unitOfWork;
            this.sliderRepository = sliderRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditSlider command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                result = new Result(false, command.Id, "Id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                result = new Result(false, command.Name, "Kaydırıcı Adı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Name.Length > 200)
            {
                result = new Result(false, command.Name, "Kaydırıcı Adı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }

            // map command to the model
            var model = Mapper.Map<Slider>(command);

            // mark the model to update
            sliderRepository.Update(model);

            // save changes to database
           await unitOfWork.SaveChangesAsync();


            result = new Result(true, model.Id, "Kaydırıcı başarıyla güncellendi.", true, 1);
            // return the result
            return await Task.FromResult(result);
        }
    }
}
