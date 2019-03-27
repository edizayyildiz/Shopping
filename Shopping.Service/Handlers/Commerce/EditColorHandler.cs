using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditColorHandler : CommandHandler<Commands.EditColor>
    {
        private readonly IRepository<Color> colorRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditColorHandler(IUnitOfWork unitOfWork, IRepository<Color> colorRepository)
        {
            this.unitOfWork = unitOfWork;
            this.colorRepository = colorRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditColor command)
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
                result = new Result(false, true, "Renk gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Name.Length > 200)
            {
                result = new Result(false, true, "Renk 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Value))
            {
                result = new Result(false, true, "Değer gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Value.Length > 200)
            {
                result = new Result(false, true, "Değer 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            // map command to the model
            var model = Mapper.Map<Color>(command);

            // mark the model to update
            colorRepository.Update(model);

            // save changes to database
           await unitOfWork.SaveChangesAsync();

            // return the result
            result = new Result(true, model.Id, "Renk başarıyla güncellendi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
