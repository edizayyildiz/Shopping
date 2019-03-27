using Shopping.Data;
using Shopping.Model.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Service.Handlers
{
    public class EditProductHandler : CommandHandler<Commands.EditProduct>
    {
        private readonly IRepository<Product> productRepository;
        private readonly IUnitOfWork unitOfWork;
        public EditProductHandler(IUnitOfWork unitOfWork, IRepository<Product> productRepository)
        {
            this.unitOfWork = unitOfWork;
            this.productRepository = productRepository;
        }
        public override async Task<dynamic> HandleAsync(Commands.EditProduct command)
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
                result = new Result(false, command.Slug, "Bağlantı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }
            if (!string.IsNullOrEmpty(command.MetaTitle) && command.MetaTitle.Length > 200)
            {
                result = new Result(false, command.MetaTitle, "Meta Başlığı 200 karakterden uzun olamaz.", true, null);
                return await Task.FromResult(result);
            }

            // map command to the model
            var model = Mapper.Map<Product>(command);

            // mark the model to update
            productRepository.Update(model);

            // save changes to database
            await unitOfWork.SaveChangesAsync();

            // return the result
            result = new Result(true, model.Id, "Ürün başarıyla güncellendi.", false, 1);
            return await Task.FromResult(result);
        }
    }
}
