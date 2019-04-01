using AutoMapper;
using Shopping.Data;
using Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class AddRecentlyDisplayedProductHandler : CommandHandler<Commands.AddRecentlyDisplayedProduct>
    {
        private readonly IRepository<RecentlyDisplayedProduct> repository;
        private readonly IUnitOfWork unitOfWork;
        public AddRecentlyDisplayedProductHandler(IUnitOfWork unitOfWork, IRepository<RecentlyDisplayedProduct> repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddRecentlyDisplayedProduct command)
        {
            Result result;
            // validate the command
            if (string.IsNullOrWhiteSpace(command.UserName))
            {
                result = new Result(false, command.UserName, "Kullanıcı adı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.UserName.Length > 100)
            {
                result = new Result(false, command.UserName, "Kullanıcı adı 100 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }


            // map command to the model
            var model = Mapper.Map<RecentlyDisplayedProduct>(command);

            // mark the model to insert
            repository.Insert(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            // return the result
            result = new Result(true, model.Id, "Ürünün son görüntülenmesi eklendi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
