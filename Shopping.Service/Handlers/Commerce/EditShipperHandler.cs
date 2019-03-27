using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditShipperHandler : CommandHandler<Commands.EditShipper>
    {
        private readonly IRepository<Shipper> shipperRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditShipperHandler(IUnitOfWork unitOfWork, IRepository<Shipper> shipperRepository)
        {
            this.unitOfWork = unitOfWork;
            this.shipperRepository = shipperRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditShipper command)
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
                result = new Result(false, command.Name, "Kargo Firma Adı gereklidir.", true, null);
                return await Task.FromResult(result);
               
            }
            if (command.Name.Length > 200)
            {
                result = new Result(false, command.Name, "Kargo Firma Adı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
                
            }
            if (string.IsNullOrWhiteSpace(command.Url))
            {
                result = new Result(false, command.Url, "Bağlantı gereklidir.", true, null);
                return await Task.FromResult(result);
                
            }
            if (command.Url.Length > 200)
            {
                result = new Result(false, command.Url, "Bağlantı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
               
            }

            // map command to the model
            var model = Mapper.Map<Shipper>(command);

            // mark the model to update
            shipperRepository.Update(model);

            // save changes to database
          await unitOfWork.SaveChangesAsync();

            // return the result
            result = new Result(true, model.Id, "Kargo firması başarıyla güncellendi.", false, 1);
            return await Task.FromResult(result);
            
        }
    }
}
