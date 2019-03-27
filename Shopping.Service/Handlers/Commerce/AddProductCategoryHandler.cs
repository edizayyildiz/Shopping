using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class AddProductCategoryHandler : CommandHandler<Commands.AddProductCategory>
    {
        private readonly IRepository<ProductCategory> productcategoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public AddProductCategoryHandler(IUnitOfWork unitOfWork, IRepository<ProductCategory> productcategoryRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productcategoryRepository = productcategoryRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.AddProductCategory command)
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
                result = new Result(false, command.Name, "Bağlantı gereklidir.", true, null);
                return await Task.FromResult(result);
            }
            if (command.Slug.Length > 200)
            {
                result = new Result(false, command.Name, "Bağlantı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }

            if (!string.IsNullOrEmpty(command.Photo) && command.Photo.Length > 200)
            {
                result = new Result(false, command.Name, "Resim 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }


            // map command to the model
            var model = Mapper.Map<ProductCategory>(command);

            // mark the model to insert
            productcategoryRepository.Insert(model);

            // save changes to database
            unitOfWork.SaveChanges();

            // return the result
            result = new Result(true, model.Id, "Ürün kategorisi başarıyla eklendi.", true, 1);
            return await Task.FromResult(result);
        }
    }
}
