using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class AddStoreHandler : CommandHandler<Commands.AddStore>
    {
        private readonly IRepository<Shopping.Model.Entities.Store> storeRepository;
        private readonly IUnitOfWork unitOfWork;
        public AddStoreHandler(IUnitOfWork unitOfWork, IRepository<Shopping.Model.Entities.Store> storeRepository)
        {
            this.unitOfWork = unitOfWork;
            this.storeRepository = storeRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddStore command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.Name))
            {
                result = new Result(false, command.Name, "Ad gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Name.Length > 200)
            {
                result = new Result(false, command.Name, "Ad 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (string.IsNullOrWhiteSpace(command.Slug))
            {
                result = new Result(false, command.Slug, "Bağlantı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Slug.Length > 200)
            {
                result = new Result(false, command.Slug, "Bağlantı 200 karakterden uzun olamaz.", true,null);
                return await Task.FromResult(result);
            }

            // map command to the model
            var model = Mapper.Map<Shopping.Model.Entities.Store>(command);

            // mark the model to insert
            storeRepository.Insert(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            // return the result
            result = new Result(true,model.Id, "Mağaza başarıyla eklendi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
