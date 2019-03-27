using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditStoreBrandHandler : CommandHandler<Commands.EditStoreBrand>
    {
        private readonly IRepository<StoreBrand> storeBrandRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditStoreBrandHandler(IUnitOfWork unitOfWork, IRepository<StoreBrand> storeBrandRepository)
        {
            this.unitOfWork = unitOfWork;
            this.storeBrandRepository = storeBrandRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditStoreBrand command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Id))
            {
                result = new Result(false, command.Id, "id gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.StoreId))
            {

                result = new Result(false, command.StoreId, "Mağaza ID gereklidir.", true, null);
                return await Task.FromResult(result);
               
            }
            if (string.IsNullOrWhiteSpace(command.BrandId))
            {
              
                result = new Result(false, command.BrandId, "Marka ID gereklidir", true, null);
                return await Task.FromResult(result);

            }
            // map command to the model
            var model = Mapper.Map<StoreBrand>(command);

            // mark the model to update
            storeBrandRepository.Update(model);

            // save changes to database
            unitOfWork.SaveChanges();

            // return the result
            return new Result(true,model.Id,  "Mağaza markası başarıyla güncellendi.", false, 1);
        }
    }
}
