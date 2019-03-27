using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class AddColorHandler : CommandHandler<Commands.AddColor>
    {
        private readonly IRepository<Color> colorRepository;
        private readonly IUnitOfWork unitOfWork;
        public AddColorHandler(IUnitOfWork unitOfWork, IRepository<Color> colorRepository)
        {
            this.unitOfWork = unitOfWork;
            this.colorRepository = colorRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddColor command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                result = new Result(false, command.Name, "Renk gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Name.Length > 200)
            {
                result = new Result(false, command.Name, "Renk 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Value))
            {
                result = new Result(false, command.Name, "Değer gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Value.Length > 200)
            {
                result = new Result(false, command.Name, "Değer 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }

            // map command to the model
            var model = Mapper.Map<Color>(command);

            // mark the model to insert
            colorRepository.Insert(model);

            // save changes to database
            unitOfWork.SaveChanges();

            // return the result
            result = new Result(true, model.Id, "Renk başarıyla eklendi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
